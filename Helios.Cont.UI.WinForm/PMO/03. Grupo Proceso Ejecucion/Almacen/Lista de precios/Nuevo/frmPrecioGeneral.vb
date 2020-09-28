Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmPrecioGeneral
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        CargarControles()
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvPrecios)
        GridCFG(dgvAlertas)
        GridCFG(GridGroupingControl1)
        GridCFG(dgvHistorialAlertas)
        lblPeriodo.Text = PeriodoGeneral
        ConteoproductosSinPrecio()
        ListarPrecioAlertasConteo()
        'AgregarNodosDefault()
    End Sub
    Dim colorx As New GridMetroColors()

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

#Region "Metodos"

    Sub AgregarNodosDefault()

        Dim CategoriaSA As New itemSA
        Dim Categoria As New List(Of item)

        Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
        NewNode.Text = "Categoria - items"
        NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
        NewNode.Font = New Font("Segoe UI Light", 8)
        treeViewAdv2.Nodes.Add(NewNode)

        Categoria = CategoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)

        Dim SubNodesSin As TreeNodeAdv = New TreeNodeAdv()
        SubNodesSin.TextColor = Color.Red
        SubNodesSin.Font = New Font("Segoe UI Light", 8)
        SubNodesSin.Text = "Sin clasificación"
        SubNodesSin.Tag = 0
        NewNode.Nodes.Add(SubNodesSin)

        For Each i In Categoria
            Dim SubNodes As TreeNodeAdv = New TreeNodeAdv()
            SubNodes.TextColor = Color.DimGray
            SubNodes.Font = New Font("Segoe UI Light", 8)
            SubNodes.Text = i.descripcion
            SubNodes.Tag = i.idItem
            NewNode.Nodes.Add(SubNodes)
        Next

     
    End Sub

    Public Sub ConteoproductosSinPrecio()
        Dim totalesSA As New TotalesAlmacenSA
        Dim totales As New List(Of totalesAlmacen)

        totales = totalesSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Me.HubTileNuevosItems.Title.Text = totales.Count
        Me.HubTileNuevosItems.Title.TextColor = Color.White
    End Sub

    Sub ListarInventarioXproducto2()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()
        'Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        dt.Columns.Add("almacen") 'idalmacen
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("cantmax")
        dt.Columns.Add("cantmin")

        For Each i In totalesAlmacenSA.GetProductoPorAlmacenTipoEx(0, cboTipoExistencia.SelectedValue, "")
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "Ultimas"
            dr(7) = i.NomAlmacen
            dr(8) = i.idAlmacen
            dr(9) = i.cantidadMaxima
            dr(10) = i.cantidadMinima
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub


    Sub ListarInventarioXproducto()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()
        Dim codigo As Integer = 0

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        dt.Columns.Add("almacen") 'idalmacen
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("cantmax")
        dt.Columns.Add("cantmin")

        For Each i In totalesAlmacenSA.GetProductoPorAlmacenTipoEx(codigo, cboTipoExistencia.SelectedValue, txtBuscar.Text.Trim)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "Ultimas"
            dr(7) = i.NomAlmacen
            dr(8) = i.idAlmacen
            dr(9) = i.cantidadMaxima
            dr(10) = i.cantidadMinima
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub ListarPrecioGeneral()
        Dim ConfiguracionPrecioSA As New ConfiguracionPrecioSA
        Dim dt As New DataTable()

        dt.Columns.Add("idPrecio")
        dt.Columns.Add("precio")
        dt.Columns.Add("tasaPorcentaje")
        dt.Columns.Add("tipo")

        For Each i In ConfiguracionPrecioSA.ListadoPrecios()
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idPrecio
            dr(1) = i.precio
            dr(2) = i.tasaPorcentaje
            dr(3) = i.tipo
            dt.Rows.Add(dr)
        Next
        dgvPrecioGeneral.DataSource = dt
        Me.dgvPrecioGeneral.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub ListarPrecioAlertas()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim TotalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()

        dt.Columns.Add("idalmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("idAlerta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("fechaInicio")
        dt.Columns.Add("fechaFin")

        TotalesAlmacen = TotalesAlmacenSA.ObtenerAlertaDePrecio(New totalesAlmacen With {.idAlmacen = 0})
        Me.HubTileAlertas.Title.Text = TotalesAlmacen.Count
        Me.HubTileAlertas.Title.TextColor = Color.White
        For Each i In TotalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = i.idItem
            dr(3) = i.descripcion
            dr(4) = i.FechaUltimoPrecioKardex  'fecha inventario
            dr(5) = i.FechaUltimoPrecioConfigurado  ' fecha config precio
            dt.Rows.Add(dr)
        Next
        dgvAlertas.DataSource = dt
        Me.dgvAlertas.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub


    Sub ListarPrecioAlertasConteo()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()

        dt.Columns.Add("idAlerta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("fechaInicio")
        dt.Columns.Add("fechaFin")


        Me.HubTileAlertas.Title.Text = TotalesAlmacenSA.ObtenerAlertaDePrecioConteo(New totalesAlmacen With {.idAlmacen = 0})
        Me.HubTileAlertas.Title.TextColor = Color.White

    End Sub

    Sub LoadProductosXalmacen()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()
        '       Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        For Each i In totalesAlmacenSA.GetListaProductosPorAlmacen(0)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "ultimas"
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub LoadProductosXalmacenXCategoria(intCategoria As Integer)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()
        '    Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        dt.Columns.Add("almacen")
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("cantmax")
        dt.Columns.Add("cantmin")
        For Each i In totalesAlmacenSA.GetListaProductosPorAlmacenPorCategoria(0, intCategoria)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "ultimas"
            dr(7) = i.NomAlmacen
            dr(8) = i.idAlmacen
            dr(9) = i.cantidadMaxima
            dr(10) = i.cantidadMinima
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub LoadProductosXalmacenSinCategoria(intCategoria As Integer)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()
        'Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        dt.Columns.Add("almacen")
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("cantmax")
        dt.Columns.Add("cantmin")
        For Each i In totalesAlmacenSA.GetListaProductosPorAlmacenSinCategoria(0, intCategoria)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "ultimas"
            dr(7) = i.NomAlmacen
            dr(8) = i.idAlmacen
            dr(9) = i.cantidadMaxima
            dr(10) = i.cantidadMinima
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub LoadProductosXalmacenSinAsignar()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()
        '  Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        dt.Columns.Add("almacen") 'idalmacen
        dt.Columns.Add("idalmacen")
        totalesAlmacen = totalesAlmacenSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Me.HubTileNuevosItems.Title.Text = totalesAlmacen.Count
        Me.HubTileNuevosItems.Title.TextColor = Color.White

        For Each i In totalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "ultimas"
            dr(7) = i.NomAlmacen
            dr(8) = i.idAlmacen
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub UbicarUltimosPreciosXproducto(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(r.GetValue("idalmacen"), r.GetValue("idItem"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt

    End Sub

    Public Sub UbicarUltimosPreciosXproducto_Alertas(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(r.GetValue("idalmacen"), r.GetValue("idAlerta"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        dgvHistorialAlertas.DataSource = dt

    End Sub

    Sub CargarControles()
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim lista As New List(Of String)
        Dim almacenSA As New almacenSA

        lista.Add("03")
        lista.Add("04")
        lista.Add("05")

        tabla = tablaSA.GetListaTablaDetalle(5, "1")

        Dim con = (From n In tabla _
                  Where Not lista.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = con

        'cboAlmacen.DisplayMember = "descripcionAlmacen"
        'cboAlmacen.ValueMember = "idAlmacen"
        'cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
    End Sub

#End Region

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Alertas"
            Case "Establecer precio Producto"
                Dim detalleItemSA As New detalleitemsSA
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()
                With frmNuevaExistencia
                    .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                    .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                    .Precios = True
                    .IdAlmacenPrecio = TmpIdAlmacen
                    ' .cboTipoExistencia.Text = cboTipoExistencia.Text
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'If datos.Count > 0 Then
                    '    If datos(0).Cuenta = "Grabado" Then
                    '        With detalleItemSA.InvocarProductoID(datos(0).ID)
                    '            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                    '            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("fecha", Nothing)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", .descripcionItem)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimenor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimenor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvmenor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc2", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimayor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimayor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvmayor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc3", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtigranmayor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtigranmayor", 0.0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvgranmayor", 0.0)
                    '            Me.dgvCompra.Table.AddNewRecord.EndEdit()
                    '        End With
                    '    End If
                    'End If

                End With
        End Select
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Alertas"

            Case "Establecer precio Producto"
                If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                    UbicarUltimosPreciosXproducto(dgvPrecios.Table.CurrentRecord)
                End If
        End Select

    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Alertas"

            Case "Establecer precio Producto"
                Me.Cursor = Cursors.WaitCursor
                If Not IsNothing(Me.dgvPrecios.Table.CurrentRecord) Then
                    Dim detalleItemSA As New detalleitemsSA
                    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                    datos.Clear()
                    With frmNuevaExistencia
                        .EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                        '.cboTipoExistencia.SelectedValue = "01"
                        .Precios = True
                        .IdAlmacenPrecio = TmpIdAlmacen
                        ' .cboTipoExistencia.Text = cboTipoExistencia.Text
                        .UCNuenExistencia.UbicarProducto(Me.dgvPrecios.Table.CurrentRecord.GetValue("idItem"))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        'If datos.Count > 0 Then
                        '    If datos(0).Cuenta = "Grabado" Then
                        '        With detalleItemSA.InvocarProductoID(datos(0).ID)
                        '            'Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                        '            'Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("fecha", Nothing)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", .descripcionItem)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimenor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimenor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvmenor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc2", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimayor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimayor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvmayor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc3", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtigranmayor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtigranmayor", 0.0)
                        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvgranmayor", 0.0)
                        '            '     Me.dgvCompra.Table.AddNewRecord.EndEdit()
                        '        End With
                        '    End If
                        'End If

                    End With
                End If


                Me.Cursor = Cursors.Arrow
        End Select
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Alertas"
            Case "Configuración de precios"
                Me.Cursor = Cursors.WaitCursor
                Dim configuracionPrecio As New configuracionPrecio
                Dim ConfiguracionPrecioSA As New ConfiguracionPrecioSA
                Try
                    If MessageBox.Show("Desea eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        If Not IsNothing(dgvPrecioGeneral.Table.CurrentRecord) Then
                            configuracionPrecio = New configuracionPrecio
                            configuracionPrecio.idPrecio = Me.dgvPrecioGeneral.Table.CurrentRecord.GetValue("idPrecio")
                            ConfiguracionPrecioSA.UpdatePrecioGeneral(configuracionPrecio)
                            Me.dgvPrecioGeneral.Table.CurrentRecord.Delete()
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Atención", Nothing, MessageBoxIcon.Error)
                End Try
                Me.Cursor = Cursors.Arrow

            Case "Establecer precio Producto"
                Me.Cursor = Cursors.WaitCursor
                Dim detalleItem As New detalleitems
                Dim detalleItemSA As New detalleitemsSA
                Try
                    If MessageBox.Show("Desea eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                            detalleItem = New detalleitems
                            detalleItem.idEmpresa = Gempresas.IdEmpresaRuc
                            detalleItem.idEstablecimiento = GEstableciento.IdEstablecimiento
                            detalleItem.codigodetalle = Me.dgvPrecios.Table.CurrentRecord.GetValue("idItem")
                            detalleItemSA.DeleteProductoAllReferences(detalleItem)
                            Me.dgvPrecios.Table.CurrentRecord.Delete()
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Atención", Nothing, MessageBoxIcon.Error)
                End Try
                Me.Cursor = Cursors.Arrow
        End Select

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Alertas"
            Case "Configuración de Precios"
                If Not IsNothing(dgvPrecioGeneral.Table.CurrentRecord) Then
                    Dim f As New frmNuevoPrecioGeneral
                    f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                    f.idPrecio = dgvPrecioGeneral.Table.CurrentRecord.GetValue("idPrecio")
                    f.Ubicar(dgvPrecioGeneral.Table.CurrentRecord.GetValue("idPrecio"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If
            Case "Establecer precio Producto"
                If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                    Dim f As New frmNuevoPrecio
                    'f.txtAlmacen.Text = cboAlmacen.Text
                    'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
                    f.txtProducto.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idItem")
                    f.txtProducto.Text = dgvPrecios.Table.CurrentRecord.GetValue("item")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If
        End Select

    End Sub

    Private Sub dgvPrecios_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPrecios.SelectedRecordsChanged

    End Sub

    Private Sub dgvPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvPrecios.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = "btUltimasEntradas"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageListAdv1.Images(0), irect)
            End If

        End If
    End Sub

    Private Sub dgvPrecios_TableControlPrepareViewStyleInfo(sender As Object, e As GridTableControlPrepareViewStyleInfoEventArgs) Handles dgvPrecios.TableControlPrepareViewStyleInfo
        If (e.Inner.ColIndex > 0) AndAlso (e.Inner.ColIndex < 7) Then
            e.Inner.Style.CellTipText = e.Inner.Style.Text
        End If
    End Sub

    Private Sub dgvPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvPrecios.TableControlPushButtonClick
        If e.Inner.ColIndex = 6 Then
            Dim f As New frmUltimasCompras
            f.txtItem.Text = Me.dgvPrecios.TableModel(e.Inner.RowIndex, 1).CellValue
            f.txtItem.ValueMember = Me.dgvPrecios.TableModel(e.Inner.RowIndex, 7).CellValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub


    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        LoadProductosXalmacen()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListarInventarioXproducto()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PopupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer1.BeforePopup
        Me.PopupControlContainer1.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            Select Case ListBox2.Text
                Case "Precio"
                    With frmNuevoPrecioGeneral
                        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                    End With

                Case "Precio x producto"
                    Dim detalleItemSA As New detalleitemsSA
                    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                    datos.Clear()
                    With frmNuevaExistencia
                        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                        .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                        .Precios = True
                        .IdAlmacenPrecio = TmpIdAlmacen
                        ' .cboTipoExistencia.Text = cboTipoExistencia.Text
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        'If datos.Count > 0 Then
                        '    If datos(0).Cuenta = "Grabado" Then
                        '        With detalleItemSA.InvocarProductoID(datos(0).ID)
                        '            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                        '            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("fecha", Nothing)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", .descripcionItem)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimenor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimenor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvmenor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc2", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimayor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimayor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvmayor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc3", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtigranmayor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtigranmayor", 0.0)
                        '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvgranmayor", 0.0)
                        '            Me.dgvCompra.Table.AddNewRecord.EndEdit()
                        '        End With
                        '    End If
                        'End If

                    End With

            End Select
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.btOperacion.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ListBox2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If ListBox2.SelectedItems.Count > 0 Then
            Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.PopupControlContainer1.ParentControl = Me.btOperacion
        Me.PopupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs)
        'Dim f As New frmPreciosGeneral
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Alertas"
                ListarPrecioAlertas()
            Case "Establecer precio Producto"

        End Select
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Alertas"
                If Not IsNothing(dgvAlertas.Table.CurrentRecord) Then
                    Dim f As New frmNuevoPrecio
                    'f.txtAlmacen.Text = cboAlmacen.Text
                    'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
                    f.txtProducto.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idPrecio")
                    f.txtProducto.Text = dgvAlertas.Table.CurrentRecord.GetValue("idProducto")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If
            Case "Establecer precio Producto"

        End Select
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        GridCFG(dgvPrecios)
        GridCFG(dgvAlertas)
        GridCFG(GridGroupingControl1)
        GridCFG(dgvHistorialAlertas)
        Select Case treeViewAdv2.SelectedNode.Text

            Case "Configuración de Precios"
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                ToolStripButton6.Visible = False
                '    CompraDeServiciosPúblicosToolStripMenuItem.Visible = False
            Case "Establecer Precio Producto", "Categoria - items"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                ToolStripButton6.Visible = True
                ' CompraDeServiciosPúblicosToolStripMenuItem.Visible = True
                GradientPanel1.Size = New Size(886, 105)
            Case "Alertas"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
                ToolStripButton6.Visible = False
                '   CompraDeServiciosPúblicosToolStripMenuItem.Visible = True
        End Select
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Parent.Text
            Case "Categoria - items"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                ToolStripButton6.Visible = True
                'CompraDeServiciosPúblicosToolStripMenuItem.Visible = True
                GradientPanel1.Size = New Size(886, 63)
                Select Case treeViewAdv2.SelectedNode.Tag
                    Case 0
                        LoadProductosXalmacenSinCategoria(0)
                    Case Else
                        LoadProductosXalmacenXCategoria(CInt(treeViewAdv2.SelectedNode.Tag))
                End Select

            Case Else

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmPrecioGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPrecioGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '///7dgdf
        txtEmpresa.Text = Gempresas.NomEmpresa
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv3.Parent = Nothing
        ToolStripButton6.Visible = True

    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDeExistenciasServiciosToolStripMenuItem.Click
        With frmNuevoPrecioGeneral
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)
        Dim detalleItemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .Precios = True
            .IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

  

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)



        Me.Cursor = Cursors.WaitCursor

        'If Me.dgvPrecios.Table.CurrentRecord.GetValue("stock") > 0 Then
        '    MessageBox.Show("Este Producto tiene Items no se puede editar")
        '    Exit Sub
        'End If


        If Not IsNothing(Me.dgvPrecios.Table.CurrentRecord) Then
            Dim detalleItemSA As New detalleitemsSA
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()


            Dim f As New frmNuevaExistencia
            f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
            '.cboTipoExistencia.SelectedValue = "01"
            f.Precios = True
            f.IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            f.UCNuenExistencia.UbicarProducto(Me.dgvPrecios.Table.CurrentRecord.GetValue("idItem"))
            f.nudCantMax.Value = Me.dgvPrecios.Table.CurrentRecord.GetValue("cantmax")
            f.nudCantMin.Value = Me.dgvPrecios.Table.CurrentRecord.GetValue("cantmin")
            f.UCNuenExistencia.Label7.Visible = False
            f.UCNuenExistencia.cboTipoExistencia.Visible = False
            f.Label2.Visible = False
            f.UCNuenExistencia.cboIgv.Visible = False

            f.StartPosition = FormStartPosition.CenterParent

            ListarInventarioXproducto2()

            f.ShowDialog()

            'With frmNuevaExistencia
            '    .EstadoManipulacion = ENTITY_ACTIONS.UPDATE
            '    '.cboTipoExistencia.SelectedValue = "01"
            '    .Precios = True
            '    .IdAlmacenPrecio = TmpIdAlmacen
            '    ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            '    .UbicarProducto(Me.dgvPrecios.Table.CurrentRecord.GetValue("idItem"))
            '    .nudCantMax.Value = Me.dgvPrecios.Table.CurrentRecord.GetValue("cantmax")
            '    .nudCantMin.Value = Me.dgvPrecios.Table.CurrentRecord.GetValue("cantmin")
            '    .cboalmacen.SelectedValue = cboAlmacen.SelectedValue
            '    .cboalmacen.Visible = False
            '    .Label12.Visible = False
            '    .Label7.Visible = False
            '    .cboTipoExistencia.Visible = False
            '    .Label2.Visible = False
            '    .cboIgv.Visible = False

            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()

            'End With



        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs)


        If Me.dgvPrecios.Table.CurrentRecord.GetValue("stock") > 0 Then
            MessageBox.Show("Este Producto tiene Items no se puede eliminar")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim detalleItem As New detalleitems
        Dim detalleItemSA As New detalleitemsSA
        Try
            If MessageBox.Show("Desea eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                    detalleItem = New detalleitems
                    detalleItem.idEmpresa = Gempresas.IdEmpresaRuc
                    detalleItem.idEstablecimiento = GEstableciento.IdEstablecimiento
                    detalleItem.codigodetalle = Me.dgvPrecios.Table.CurrentRecord.GetValue("idItem")
                    detalleItemSA.DeleteProductoAllReferences(detalleItem)
                    Me.dgvPrecios.Table.CurrentRecord.Delete()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", Nothing, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click
  

    End Sub

 

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub dgvAlertas_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvAlertas.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        dgvHistorialAlertas.Table.Records.DeleteAll()
        If Not IsNothing(dgvAlertas.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto_Alertas(dgvAlertas.Table.CurrentRecord)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvAlertas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAlertas.TableControlCellClick

    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                Dim f As New frmNuevoPrecio
                'f.txtAlmacen.Text = cboAlmacen.Text
                'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
                f.txtAlmacen.Text = dgvPrecios.Table.CurrentRecord.GetValue("almacen")
                f.txtAlmacen.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idalmacen")
                f.txtProducto.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idItem")
                f.txtProducto.Text = dgvPrecios.Table.CurrentRecord.GetValue("item")
                f.txtGrav.Text = dgvPrecios.Table.CurrentRecord.GetValue("destino")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv3 Then
            Dim f As New frmNuevoPrecio
            Dim prodSA As New detalleitemsSA
            'f.txtAlmacen.Text = cboAlmacen.Text
            'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
            f.txtAlmacen.Text = dgvAlertas.Table.CurrentRecord.GetValue("almacen")
            f.txtAlmacen.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idalmacen")
            f.txtProducto.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idAlerta")
            f.txtProducto.Text = dgvAlertas.Table.CurrentRecord.GetValue("descripcion")
            f.txtGrav.Text = prodSA.InvocarProductoID(CInt(dgvAlertas.Table.CurrentRecord.GetValue("idAlerta"))).origenProducto
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub dgvPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrecios.TableControlCellClick

    End Sub

    Private Sub HubTileNuevosItems_Click(sender As Object, e As EventArgs) Handles HubTileNuevosItems.Click
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv3.Parent = Nothing
        ToolStripButton6.Visible = True
        '  CompraDeServiciosPúblicosToolStripMenuItem.Visible = True
        GradientPanel1.Size = New Size(886, 0)
        LoadProductosXalmacenSinAsignar()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvPrecioGeneral_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrecioGeneral.TableControlCellClick

    End Sub

    Private Sub dgvPrecios_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPrecios.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        GridGroupingControl1.Table.Records.DeleteAll()
        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto(dgvPrecios.Table.CurrentRecord)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub HubTileAlertas_Click(sender As Object, e As EventArgs) Handles HubTileAlertas.Click
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = TabControlAdv1
        ToolStripButton6.Visible = False
        '   CompraDeServiciosPúblicosToolStripMenuItem.Visible = True
        dgvHistorialAlertas.Table.Records.DeleteAll()
        ListarPrecioAlertas()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                Dim f As New frmNuevoPrecio
                'f.txtAlmacen.Text = cboAlmacen.Text
                'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
                'f.txtAlmacen.Text = dgvPrecios.Table.CurrentRecord.GetValue("almacen")
                'f.txtAlmacen.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idalmacen")
                f.txtProducto.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idItem")
                f.txtProducto.Text = dgvPrecios.Table.CurrentRecord.GetValue("item")
                f.txtGrav.Text = dgvPrecios.Table.CurrentRecord.GetValue("destino")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv3 Then
            Dim f As New frmNuevoPrecio
            Dim prodSA As New detalleitemsSA
            'f.txtAlmacen.Text = cboAlmacen.Text
            'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
            'f.txtAlmacen.Text = dgvAlertas.Table.CurrentRecord.GetValue("almacen")
            'f.txtAlmacen.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idalmacen")
            f.txtProducto.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idAlerta")
            f.txtProducto.Text = dgvAlertas.Table.CurrentRecord.GetValue("descripcion")
            f.txtGrav.Text = prodSA.InvocarProductoID(CInt(dgvAlertas.Table.CurrentRecord.GetValue("idAlerta"))).origenProducto
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto(dgvPrecios.Table.CurrentRecord)
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            ListarPrecioGeneral()
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv3 Then
            ListarPrecioAlertas()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

End Class