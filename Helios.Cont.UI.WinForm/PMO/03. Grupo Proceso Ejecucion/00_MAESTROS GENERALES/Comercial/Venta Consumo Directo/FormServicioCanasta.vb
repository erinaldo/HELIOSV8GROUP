Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Helios.Cont.Presentation.WinForm

Public Class FormServicioCanasta
    Implements IBusquedaAvanzadaProductos

    Private idAlmacen As Integer
    Public Property validaStocks() As Boolean

    ''' <summary>
    ''' Valida el ingreso de un articulo, con un precio de venta
    ''' </summary>
    ''' <returns></returns>
    Public Property validaSelPrecioVenta() As Boolean
    Public Property monedaVenta As String
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim thread As System.Threading.Thread
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            'Case Keys.F7
            '    ToolStripButton1.PerformClick()

            Case Keys.F6
                Me.Hide()

                'Case Keys.F10
                '    ToolStripButton2.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New(id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'GridCFG(GridTotales)
        'FormatoGridAvanzado(GridTotales, False, False, 12)
        FormatoGridAvanzado(GridTotales, False, False, 11.5F)

        GridCFG(GridInventario)
        idAlmacen = id
        Me.KeyPreview = True
    End Sub

    Public Sub New(id As Integer, producto As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'GridCFG(GridTotales)
        FormatoGridAvanzado(GridTotales, False, False, 11.5F)

        GridCFG(GridInventario)
        idAlmacen = id
        txtFiltrar.Text = producto
        ObtenerCanastaVentaFiltro("01", txtFiltrar.Text.Trim)
        Me.KeyPreview = True
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(GridTotales, False, False, 11.5F)

        GridCFG(GridInventario)
        Me.KeyPreview = True
    End Sub
#End Region

#Region "Methods"

    'Private Sub threadArticulosSinAlmacen()
    '    thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioSinAlmacen(txtFiltrar.Text.Trim)))
    '    thread.Start()
    'End Sub

    'Private Sub GetInventarioSinAlmacen(serachText As String)
    '    Dim ItemSA As New detalleitemsSA
    '    Dim products = ItemSA.GetArticulosSinAlmacenSearchText(General.Gempresas.IdEmpresaRuc, serachText)
    '    Dim dt As New DataTable
    '    dt.Columns.Add("idItem")
    '    dt.Columns.Add("destino")
    '    dt.Columns.Add("descripcion")
    '    dt.Columns.Add("unidad")
    '    dt.Columns.Add("tipo")
    '    dt.Columns.Add("pvmenor")
    '    dt.Columns.Add("pvmenorme")
    '    dt.Columns.Add("pvmayor")
    '    dt.Columns.Add("pvmayorme")
    '    dt.Columns.Add("pvGmayor")
    '    dt.Columns.Add("pvGmayorme")

    '    For Each i In products
    '        dt.Rows.Add(
    '            i.codigodetalle,
    '            i.origenProducto,
    '            i.descripcionItem,
    '            i.unidad1,
    '            i.tipoExistencia,
    '            i.precioMenor.GetValueOrDefault.ToString("N2"),
    '            0,
    '            i.precioMayor.GetValueOrDefault.ToString("N2"),
    '            0,
    '            i.precioGranMayor.GetValueOrDefault.ToString("N2"),
    '            0)
    '    Next
    '    setDataSource(dt)
    'End Sub

    Private Sub ObtenerCanastaVentaFiltroCodigo(strTipoExistencia As String, strProducto As String)
        'Dim CanastaSA As New TotalesAlmacenSA
        'Dim listaSA As New ListadoPrecioSA
        'Dim ItemSA As New detalleitemsSA
        ''Dim lista As New listadoPrecios
        'Dim dt As New DataTable()
        'Try
        '    dt.Columns.Add("destino", GetType(String))
        '    dt.Columns.Add("idItem", GetType(Integer))
        '    dt.Columns.Add("descripcion", GetType(String))
        '    dt.Columns.Add("unidad", GetType(String))
        '    dt.Columns.Add("idPres", GetType(String))
        '    dt.Columns.Add("presentacion", GetType(String))
        '    dt.Columns.Add("cantidad", GetType(Decimal))
        '    dt.Columns.Add("puKardexmn", GetType(Decimal))
        '    dt.Columns.Add("puKardexme", GetType(Decimal))
        '    dt.Columns.Add("importeMn", GetType(Decimal))
        '    dt.Columns.Add("importeME", GetType(Decimal))
        '    dt.Columns.Add("pvmenor", GetType(Decimal))
        '    dt.Columns.Add("pvmenorme", GetType(Decimal))
        '    dt.Columns.Add("pvmayor", GetType(Decimal))
        '    dt.Columns.Add("pvmayorme", GetType(Decimal))
        '    dt.Columns.Add("pvGmayor", GetType(Decimal))
        '    dt.Columns.Add("pvGmayorme", GetType(Decimal))
        '    dt.Columns.Add("codigoLote")
        '    dt.Columns.Add("idalmacen")
        '    dt.Columns.Add("tipo")
        '    dt.Columns.Add("fechaVcto")

        '    Dim cprecioVentaFinalMenorMN As Decimal = 0
        '    Dim cprecioVentaFinalMenorME As Decimal = 0
        '    Dim cmontoDsctounitMenorMN As Decimal = 0
        '    Dim cmontoDsctounitMenorME As Decimal = 0
        '    Dim cprecioVentaFinalMayorMN As Decimal = 0
        '    Dim cprecioVentaFinalGMayorMN As Decimal = 0
        '    Dim cprecioVentaFinalMayorME As Decimal = 0
        '    Dim cprecioVentaFinalGMayorME As Decimal = 0
        '    Dim cdetalleMenor As String = Nothing
        '    Dim cdetalleMayor As String = Nothing
        '    Dim cdetalleGMayor As String = Nothing

        '    'For Each i As totalesAlmacen In CanastaSA.GetInventarioParaVentaAcumuladoCodigo(
        '    '    New totalesAlmacen With
        '    '    {
        '    '    .idAlmacen = idAlmacen,
        '    '    .tipoExistencia = strTipoExistencia,
        '    '    .descripcion = strProducto,
        '    '    .NomAlmacen = ""
        '    '    })

        '    Dim products = ItemSA.GetArticulosSinAlmacenSearchCodigo(General.Gempresas.IdEmpresaRuc, strProducto)

        '    For Each i In products

        '        '  If i.cantidad > 0 Then
        '        'Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / (i.cantidad)
        '        'Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / (i.cantidad)

        '        cprecioVentaFinalMenorMN = i.precioMenor
        '        cprecioVentaFinalMayorMN = i.precioMayor
        '        cprecioVentaFinalGMayorMN = i.precioGranMayor

        '        cprecioVentaFinalMenorME = i.precioMenorME
        '        cprecioVentaFinalMayorME = i.precioMayorME
        '        cprecioVentaFinalGMayorME = i.precioGranMayorME

        '        Dim dr As DataRow = dt.NewRow()
        '        dr(0) = i.origenProducto
        '        dr(1) = i.codigodetalle ' i.idItem
        '        dr(2) = i.descripcionItem
        '        dr(3) = i.unidad1
        '        dr(4) = "-"
        '        dr(5) = String.Empty
        '        dr(6) = 0
        '        dr(7) = 0
        '        dr(8) = 0
        '        dr(9) = 0
        '        dr(10) = 0

        '        dr(11) = cprecioVentaFinalMenorMN
        '        dr(12) = cprecioVentaFinalMenorME
        '        dr(13) = cprecioVentaFinalMayorMN
        '        dr(14) = cprecioVentaFinalMayorME
        '        dr(15) = cprecioVentaFinalGMayorMN
        '        dr(16) = cprecioVentaFinalGMayorME
        '        dr(17) = "-"
        '        dr(18) = i.idAlmacen
        '        dr(19) = "-"
        '        dr(20) = "-"
        '        dt.Rows.Add(dr)
        '        '   End If
        '    Next
        '    GridTotales.DataSource = dt
        '    GridTotales.TableDescriptor.Relations.Clear()
        '    GridTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        '    GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '    'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
        '    GridTotales.GroupDropPanel.Visible = True
        '    GridTotales.TableDescriptor.GroupedColumns.Clear()
        '    GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        '    GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '    GridTotales.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        '    GridTotales.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        '    GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '    GridTotales.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
        '    GridInventario.Table.Records.DeleteAll()
        '    Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        'Catch ex As Exception
        '    MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        'End Try
    End Sub

    Private Sub ObtenerCanastaVentaMarca(strTipoExistencia As String, Marca As String)
        'Dim CanastaSA As New TotalesAlmacenSA
        'Dim listaSA As New ListadoPrecioSA
        ''Dim lista As New listadoPrecios

        'Dim dt As New DataTable()
        'Try
        '    dt.Columns.Add("destino", GetType(String))
        '    dt.Columns.Add("idItem", GetType(Integer))
        '    dt.Columns.Add("descripcion", GetType(String))
        '    dt.Columns.Add("unidad", GetType(String))
        '    dt.Columns.Add("idPres", GetType(String))
        '    dt.Columns.Add("presentacion", GetType(String))
        '    dt.Columns.Add("cantidad", GetType(Decimal))
        '    dt.Columns.Add("puKardexmn", GetType(Decimal))
        '    dt.Columns.Add("puKardexme", GetType(Decimal))
        '    dt.Columns.Add("importeMn", GetType(Decimal))
        '    dt.Columns.Add("importeME", GetType(Decimal))
        '    dt.Columns.Add("pvmenor", GetType(Decimal))
        '    dt.Columns.Add("pvmenorme", GetType(Decimal))
        '    dt.Columns.Add("pvmayor", GetType(Decimal))
        '    dt.Columns.Add("pvmayorme", GetType(Decimal))
        '    dt.Columns.Add("pvGmayor", GetType(Decimal))
        '    dt.Columns.Add("pvGmayorme", GetType(Decimal))
        '    dt.Columns.Add("codigoLote")
        '    dt.Columns.Add("idalmacen")
        '    dt.Columns.Add("tipo")
        '    dt.Columns.Add("fechaVcto")

        '    'ListView1.Items.Clear()
        '    Dim cprecioVentaFinalMenorMN As Decimal = 0
        '    Dim cprecioVentaFinalMenorME As Decimal = 0
        '    Dim cmontoDsctounitMenorMN As Decimal = 0
        '    Dim cmontoDsctounitMenorME As Decimal = 0
        '    Dim cprecioVentaFinalMayorMN As Decimal = 0
        '    Dim cprecioVentaFinalGMayorMN As Decimal = 0
        '    Dim cprecioVentaFinalMayorME As Decimal = 0
        '    Dim cprecioVentaFinalGMayorME As Decimal = 0
        '    Dim cdetalleMenor As String = Nothing
        '    Dim cdetalleMayor As String = Nothing
        '    Dim cdetalleGMayor As String = Nothing

        '    For Each i As totalesAlmacen In CanastaSA.GetBusquedaAvanzadaProductosSinAlmacen(
        '        New detalleitems With
        '        {
        '        .tipoExistencia = strTipoExistencia,
        '        .idEmpresa = Gempresas.IdEmpresaRuc,
        '        .unidad2 = Marca},
        '        "MARCA")
        '        '  If i.cantidad > 0 Then
        '        'Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / (i.cantidad)
        '        'Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / (i.cantidad)

        '        cprecioVentaFinalMenorMN = i.precioVentaFinalMenorMN
        '        cprecioVentaFinalMayorMN = i.precioVentaFinalMayorMN
        '        cprecioVentaFinalGMayorMN = i.precioVentaFinalGMayorMN

        '        cprecioVentaFinalMenorME = i.precioVentaFinalMenorME
        '        cprecioVentaFinalMayorME = i.precioVentaFinalMayorME
        '        cprecioVentaFinalGMayorME = i.precioVentaFinalGMayorME

        '        Dim dr As DataRow = dt.NewRow()
        '        dr(0) = i.origenRecaudo
        '        dr(1) = i.idItem
        '        dr(2) = i.descripcion
        '        dr(3) = i.unidadMedida
        '        dr(4) = i.Marca ' i.Presentacion
        '        dr(5) = i.NomAlmacen
        '        dr(6) = i.cantidad
        '        dr(7) = 0
        '        dr(8) = 0
        '        dr(9) = 0
        '        dr(10) = 0

        '        dr(11) = cprecioVentaFinalMenorMN
        '        dr(12) = cprecioVentaFinalMenorME
        '        dr(13) = cprecioVentaFinalMayorMN
        '        dr(14) = cprecioVentaFinalMayorME
        '        dr(15) = cprecioVentaFinalGMayorMN
        '        dr(16) = cprecioVentaFinalGMayorME
        '        dr(17) = "-"
        '        dr(18) = i.idAlmacen
        '        dr(19) = "-"
        '        dr(20) = "-"
        '        dt.Rows.Add(dr)
        '        '   End If
        '    Next
        '    GridTotales.DataSource = dt
        '    GridTotales.TableDescriptor.Relations.Clear()
        '    GridTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        '    GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '    'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
        '    GridTotales.GroupDropPanel.Visible = True
        '    GridTotales.TableDescriptor.GroupedColumns.Clear()
        '    GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        '    GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '    GridTotales.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        '    GridTotales.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        '    GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '    GridTotales.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
        '    GridInventario.Table.Records.DeleteAll()
        '    Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        'Catch ex As Exception
        '    MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        'End Try
    End Sub

    Private Sub ObtenerCanastaVentaGRUPO(strTipoExistencia As String, idCategoria As Integer)
        Dim CanastaSA As New TotalesAlmacenSA
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
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))
            dt.Columns.Add("codigoLote")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("fechaVcto")

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

            For Each i As totalesAlmacen In CanastaSA.GetBusquedaAvanzadaProductos(
                New detalleitems With
                {
                .tipoExistencia = strTipoExistencia,
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idItem = idCategoria},
                "CLASIFICACION")
                '  If i.cantidad > 0 Then
                'Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / (i.cantidad)
                'Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / (i.cantidad)


                cprecioVentaFinalMenorMN = i.precioVentaFinalMenorMN
                cprecioVentaFinalMayorMN = i.precioVentaFinalMayorMN
                cprecioVentaFinalGMayorMN = i.precioVentaFinalGMayorMN

                cprecioVentaFinalMenorME = i.precioVentaFinalMenorMN
                cprecioVentaFinalMayorME = i.precioVentaFinalMayorME
                cprecioVentaFinalGMayorME = i.precioVentaFinalGMayorME

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.origenRecaudo
                dr(1) = i.idItem
                dr(2) = i.descripcion
                dr(3) = i.unidadMedida
                dr(4) = i.Marca ' i.Presentacion
                dr(5) = i.NomAlmacen
                dr(6) = i.cantidad
                dr(7) = 0
                dr(8) = 0
                dr(9) = 0
                dr(10) = 0

                dr(11) = cprecioVentaFinalMenorMN
                dr(12) = cprecioVentaFinalMenorME
                dr(13) = cprecioVentaFinalMayorMN
                dr(14) = cprecioVentaFinalMayorME
                dr(15) = cprecioVentaFinalGMayorMN
                dr(16) = cprecioVentaFinalGMayorME
                dr(17) = "-"
                dr(18) = i.idAlmacen
                dr(19) = "-"
                dr(20) = "-"
                dt.Rows.Add(dr)
                '   End If
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Relations.Clear()
            GridTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            GridTotales.GroupDropPanel.Visible = True
            GridTotales.TableDescriptor.GroupedColumns.Clear()
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            GridTotales.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GridTotales.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridTotales.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
            GridInventario.Table.Records.DeleteAll()
            Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub ObtenerCanastaVentaFiltro(strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
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
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))
            dt.Columns.Add("codigoLote")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("fechaVcto")

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
            Dim ItemSA As New servicioSA

            Dim products = ItemSA.GetServicioSinAlmacenSearchText(General.Gempresas.IdEmpresaRuc, strProducto)

            For Each i In products
                'New totalesAlmacen With
                '{
                '.Moneda = monedaVenta,
                '.tipoExistencia = strTipoExistencia,
                '.descripcion = strProducto,
                '.NomAlmacen = ""
                '})
                '  If i.cantidad > 0 Then
                'Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / (i.cantidad)
                'Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / (i.cantidad)

                cprecioVentaFinalMenorMN = i.menor
                cprecioVentaFinalMayorMN = i.mayor
                cprecioVentaFinalGMayorMN = i.gMayor

                cprecioVentaFinalMenorME = i.menorME
                cprecioVentaFinalMayorME = i.mayorME
                cprecioVentaFinalGMayorME = i.gMayorME

                Dim dr As DataRow = dt.NewRow()
                'dr(0) = i.origenRecaudo
                'dr(1) = i.idItem
                'dr(2) = i.descripcion
                'dr(3) = i.unidadMedida
                'dr(4) = i.Marca ' i.Presentacion
                'dr(5) = i.NomAlmacen
                'dr(6) = i.cantidad
                'dr(7) = 0
                'dr(8) = 0
                'dr(9) = 0
                'dr(10) = 0

                dr(0) = i.tipoExist
                dr(1) = i.idServicio  ' i.idItem
                dr(2) = i.descripcion
                dr(3) = i.unidadMedida
                dr(4) = "-"
                dr(5) = String.Empty
                dr(6) = 0
                dr(7) = 0
                dr(8) = 0
                dr(9) = 0
                dr(10) = 0

                dr(11) = cprecioVentaFinalMenorMN
                dr(12) = cprecioVentaFinalMenorME
                dr(13) = cprecioVentaFinalMayorMN
                dr(14) = cprecioVentaFinalMayorME
                dr(15) = cprecioVentaFinalGMayorMN
                dr(16) = cprecioVentaFinalGMayorME
                dr(17) = "-"
                dr(18) = "-"
                dr(19) = "-"
                dr(20) = "-"
                dt.Rows.Add(dr)
                '   End If
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Relations.Clear()
            GridTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            GridTotales.GroupDropPanel.Visible = True
            GridTotales.TableDescriptor.GroupedColumns.Clear()
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            GridTotales.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GridTotales.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridTotales.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
            GridInventario.Table.Records.DeleteAll()
            Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCanastaVentaFiltroForma2(strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
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
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))
            dt.Columns.Add("codigoLote")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("fechaVcto")

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

            For Each i As totalesAlmacen In CanastaSA.GetInventarioParaVentaAcumuladoForma2(New totalesAlmacen _
                                                                                      With {
                                                               .tipoExistencia = strTipoExistencia,
                                                               .descripcion = strProducto,
                                                               .NomAlmacen = ""})
                '  If i.cantidad > 0 Then
                'Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / (i.cantidad)
                'Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / (i.cantidad)

                cprecioVentaFinalMenorMN = i.precioVentaFinalMenorMN
                cprecioVentaFinalMayorMN = i.precioVentaFinalMayorMN
                cprecioVentaFinalGMayorMN = i.precioVentaFinalGMayorMN

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.origenRecaudo
                dr(1) = i.idItem
                dr(2) = i.descripcion
                dr(3) = i.unidadMedida
                dr(4) = i.Marca
                dr(5) = i.NomAlmacen
                dr(6) = i.cantidad
                dr(7) = 0
                dr(8) = 0
                dr(9) = 0
                dr(10) = 0

                dr(11) = cprecioVentaFinalMenorMN
                dr(12) = cprecioVentaFinalMenorME
                dr(13) = cprecioVentaFinalMayorMN
                dr(14) = cprecioVentaFinalMayorME
                dr(15) = cprecioVentaFinalGMayorMN
                dr(16) = cprecioVentaFinalGMayorME
                dr(17) = "-"
                dr(18) = i.idAlmacen
                dr(19) = "-"
                dr(20) = "-"
                dt.Rows.Add(dr)
                '   End If
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Relations.Clear()
            GridTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            GridTotales.GroupDropPanel.Visible = True
            GridTotales.TableDescriptor.GroupedColumns.Clear()
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            GridTotales.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GridTotales.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridTotales.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
            GridInventario.Table.Records.DeleteAll()
            Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCanastaVentaFiltroForma3(strTipoExistencia As String, strProducto As String)

        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios
        'Dim objAlmacen As New totalesAlmacen
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
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))
            dt.Columns.Add("codigoLote")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("fechaVcto")

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
            Dim ItemSA As New detalleitemsSA
            Dim NuevaDescripcion As String = String.Empty
            Dim delimitadores() As String = {" "}
            Dim vectoraux() As String
            vectoraux = strProducto.Split(delimitadores, StringSplitOptions.None)

            'mostrar resultado
            For Each item As String In vectoraux
                NuevaDescripcion += item & "%"
            Next

            'objAlmacen.descripcion = NuevaDescripcion ' String.Concat("%", NuevaDescripcion)
            'objAlmacen.tipoExistencia = strTipoExistencia

            Dim products = ItemSA.GetArticulosSinAlmacenSearchText(General.Gempresas.IdEmpresaRuc, strProducto)

            For Each i In products

                cprecioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
                cprecioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
                cprecioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault

                Dim dr As DataRow = dt.NewRow()
                'dr(0) = i.origenProducto
                'dr(1) = i.codigodetalle ' i.idItem
                'dr(2) = i.descripcionItem
                'dr(3) = i.unidad1
                'dr(4) = "-"
                'dr(5) = String.Empty
                'dr(6) = 0
                'dr(7) = 0
                'dr(8) = 0
                'dr(9) = 0
                'dr(10) = 0
                dr(0) = i.origenProducto
                dr(1) = i.codigodetalle ' i.idItem
                dr(2) = i.descripcionItem
                dr(3) = i.unidad1
                dr(4) = "-"
                dr(5) = String.Empty
                dr(6) = 0
                dr(7) = 0
                dr(8) = 0
                dr(9) = 0
                dr(10) = 0

                dr(11) = cprecioVentaFinalMenorMN
                dr(12) = cprecioVentaFinalMenorME
                dr(13) = cprecioVentaFinalMayorMN
                dr(14) = cprecioVentaFinalMayorME
                dr(15) = cprecioVentaFinalGMayorMN
                dr(16) = cprecioVentaFinalGMayorME
                dr(17) = "-"
                dr(18) = i.idAlmacen
                dr(19) = "-"
                dr(20) = "-"
                dt.Rows.Add(dr)
                '   End If
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Relations.Clear()
            GridTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            GridTotales.GroupDropPanel.Visible = True
            GridTotales.TableDescriptor.GroupedColumns.Clear()
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            GridTotales.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GridTotales.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridTotales.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
            GridInventario.Table.Records.DeleteAll()
            Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCanastaVentaFiltroDolares(strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
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
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))
            dt.Columns.Add("codigoLote")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("fechaVcto")

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

            For Each i As totalesAlmacen In CanastaSA.GetInventarioParaVentaAcumuladoDolares(New totalesAlmacen With
                                                                                            {
                                                                                            .tipoExistencia = strTipoExistencia,
                                                                                            .descripcion = strProducto,
                                                                                            .NomAlmacen = ""})
                '  If i.cantidad > 0 Then
                'Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / (i.cantidad)
                'Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / (i.cantidad)

                cprecioVentaFinalMenorMN = i.precioVentaFinalMenorMN * Val(txtTipoCambio.Text)
                cprecioVentaFinalMayorMN = i.precioVentaFinalMayorMN * Val(txtTipoCambio.Text)
                cprecioVentaFinalGMayorMN = i.precioVentaFinalGMayorMN * Val(txtTipoCambio.Text)

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.origenRecaudo
                dr(1) = i.idItem
                dr(2) = i.descripcion
                dr(3) = i.unidadMedida
                dr(4) = i.Presentacion
                dr(5) = i.NomAlmacen
                dr(6) = i.cantidad
                dr(7) = 0
                dr(8) = 0
                dr(9) = 0
                dr(10) = 0

                dr(11) = cprecioVentaFinalMenorMN
                dr(12) = cprecioVentaFinalMenorME
                dr(13) = cprecioVentaFinalMayorMN
                dr(14) = cprecioVentaFinalMayorME
                dr(15) = cprecioVentaFinalGMayorMN
                dr(16) = cprecioVentaFinalGMayorME
                dr(17) = "-"
                dr(18) = i.idAlmacen
                dr(19) = "-"
                dr(20) = "-"
                dt.Rows.Add(dr)
                '   End If
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Relations.Clear()
            GridTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            GridTotales.GroupDropPanel.Visible = True
            GridTotales.TableDescriptor.GroupedColumns.Clear()
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            GridTotales.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GridTotales.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GridTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridTotales.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
            GridInventario.Table.Records.DeleteAll()
            Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors
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
        grid.Table.DefaultRecordRowHeight = 25
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Dim tipoMercaderia As String = "GS"
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 2 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)

                If CheckBoxTC.Checked = False Then
                    If (ChFiltro2.Checked = True) Then
                        'threadArticulosSinAlmacen()
                        ObtenerCanastaVentaFiltro(tipoMercaderia, txtFiltrar.Text.Trim)
                    ElseIf (ChFiltro2.Checked = False) Then
                        'ObtenerCanastaVentaFiltroForma2(tipoMercaderia, txtFiltrar.Text.Trim)
                        'threadArticulosSinAlmacen()
                        ObtenerCanastaVentaFiltroForma3(tipoMercaderia, txtFiltrar.Text.Trim)
                    End If

                ElseIf CheckBoxTC.Checked = True Then
                    'If txtTipoCambio.Text.Trim.Length > 0 Then
                    '    If IsNumeric(txtTipoCambio.Text) Then
                    '        If Val(txtTipoCambio.Text) > 0 Then
                    '            ObtenerCanastaVentaFiltroDolares(tipoMercaderia, txtFiltrar.Text.Trim)
                    '        Else
                    '            txtTipoCambio.Select()
                    '        End If
                    '    Else
                    '        txtTipoCambio.Select()
                    '    End If
                    'Else
                    '    txtTipoCambio.Select()
                    'End If
                End If

                '  lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
            Else
                '   lblEstado.Text = "Digitar un producto válido!"
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If GridTotales.Table.Records.Count > 0 Then

                ''GridTotales.Table.Records(0).BeginEdit()
                'Me.GridTotales.TableControl.CurrentCell.MoveTo(3, 1, GridSetCurrentCellOptions.SetFocus)
                'GridTotales.Table.Records(0).SetCurrent()
                'GridTotales.Focus()

                Dim colIndex As Integer = Me.GridTotales.TableDescriptor.FieldToColIndex(0)
                Dim rowIndex As Integer = Me.GridTotales.Table.Records(0).GetRowIndex()
                Me.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                Me.GridTotales.Focus()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridTotales_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                If Me.GridTotales.Table.CurrentRecord IsNot Nothing Then
                    Dim precioMenor = Decimal.Parse(GridTotales.Table.CurrentRecord.GetValue("pvmenor"))
                    GetproductoUnicoV2(1, "Precio por Menor", precioMenor)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar stock!")
        End Try

    End Sub

    Private Sub GridTotales_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridTotales.SelectedRecordsChanged
        If GridTotales.Table.Records.Count > 0 Then
            If e.SelectedRecord IsNot Nothing Then
                If Panellotes.Visible = True Then
                    GetInventarioLotesByItem(e.SelectedRecord.Record)
                End If
            End If
        End If
    End Sub

    Private Sub GetInventarioLotesByItem(record As Record)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim dt As New DataTable
        With dt.Columns
            .Add("descripcion")
            .Add("cantidad")
            .Add("codigoLote")
            .Add("nroLote")
            .Add("fechaVcto")
            .Add("montoMN")
            .Add("montoME")
            .Add("tipo")
            .Add("puIva")
            .Add("puSinIva")
        End With

        For Each i In CanastaSA.GetDetalleLoteXproducto(New totalesAlmacen With
                                                        {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                        .idAlmacen = Integer.Parse(record.GetValue("idalmacen")),
                                                        .idItem = Integer.Parse(record.GetValue("idItem"))
                                                        })


            If i.cantidad > 0 Then
                Dim valPrecUnitario As Decimal = 0
                Dim precioCompraConIva As Decimal = 0
                If i.CustomLote.productoSustentado = True Then
                    valPrecUnitario = CDec(i.importeSoles) / CDec(i.cantidad)
                    precioCompraConIva = 0
                    If i.origenRecaudo = 1 Then
                        precioCompraConIva = valPrecUnitario + (valPrecUnitario * 0.18)
                    Else
                        precioCompraConIva = valPrecUnitario
                    End If
                Else
                    valPrecUnitario = CDec(i.importeSoles) / CDec(i.cantidad)
                    precioCompraConIva = 0
                End If
                dt.Rows.Add(
                i.descripcion,
                i.cantidad,
                i.CustomLote.codigoLote,
                i.CustomLote.nroLote,
                If(i.CustomLote.fechaVcto.HasValue, i.CustomLote.fechaVcto, "-"),
                i.importeSoles,
                i.importeDolares,
                If(i.CustomLote.productoSustentado = True, "Doc.", "Not."),
                precioCompraConIva,
                valPrecUnitario)
            End If
        Next
        GridInventario.DataSource = dt
        GridInventario.TableDescriptor.Relations.Clear()
        GridInventario.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        GridInventario.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridInventario.GroupDropPanel.Visible = True
        GridInventario.TableDescriptor.GroupedColumns.Clear()
        GridInventario.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridInventario.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        GridInventario.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GridInventario.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GridInventario.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridInventario.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
    End Sub

    Private Sub GetproductoSelect()
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim sa As New TotalesAlmacenSA
        Dim r As Record

        r = GridTotales.Table.CurrentRecord
        Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))

        If precios.Count = 0 Then
            MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim listaInventario = GetMappingInventarioVerificado(r, precios.First)

        'Dim obj = sa.GetUbicarArticuloLote(
        '    New totalesAlmacen With
        '    {
        '    .idAlmacen = Integer.Parse(r.GetValue("idalmacen")),
        '    .idItem = Val(r.GetValue("idItem")),
        '    .codigoLote = Integer.Parse(r.GetValue("codigoLote"))
        '    })

        'obj.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
        'obj.idAlmacen = Integer.Parse(r.GetValue("idalmacen"))
        'obj.NomAlmacen = r.GetValue("presentacion")

        'obj.PMprecioMN = precios.FirstOrDefault.precioMN ' Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
        'obj.PMprecioME = precios.FirstOrDefault.precioME 'Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciome")
        'obj.tipoConfiguracion = precios.FirstOrDefault.idPrecio 'Me.GridGroupingControl2.Table.CurrentRecord.GetValue("idPrecio")
        'obj.Marca = r.GetValue("tipo")

        If listaInventario.Count > 0 Then
            Dim miInterfaz As IListaInventario = TryCast(Me.Owner, IListaInventario)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarListaArticulos(listaInventario)
        End If
    End Sub

#Region "Agregera Producto Unico"
    Private Sub GetproductoUnico(idPrecio As Integer, nombre As String, valorPrecio As Decimal)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim sa As New TotalesAlmacenSA
        Dim r As Record
        r = GridTotales.Table.CurrentRecord
        'Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))

        If valorPrecio <= 0 Then
            MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim conf As New configuracionPrecioProducto With
        {
        .idPrecio = idPrecio,
        .descripcion = nombre,
        .precioMN = valorPrecio,
        .precioME = 0
        }

        Dim listaInventario = GetInventarioUnico(r, conf)

        If listaInventario.Count > 0 Then
            Dim miInterfaz As IListaInventario = TryCast(Me.Owner, IListaInventario)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarListaArticulos(listaInventario)
        End If
    End Sub

    Private Sub GetproductoUnicoV2(idPrecio As Integer, nombre As String, valorPrecio As Decimal)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim sa As New TotalesAlmacenSA
        Dim listaInventario As List(Of totalesAlmacen)
        Dim r As Record
        r = GridTotales.Table.CurrentRecord
        ''Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))
        'If validaSelPrecioVenta = True Then
        '    If valorPrecio <= 0 Then
        '        MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If
        'End If

        listaInventario = New List(Of totalesAlmacen)
        Select Case monedaVenta
            Case "SOL"
                Dim conf As New configuracionPrecioProducto With
                    {
                    .idPrecio = idPrecio,
                    .descripcion = nombre,
                    .precioMN = valorPrecio,
                    .precioME = 0
                }

                listaInventario = GetInventarioUnicoV2(r, conf)
            Case "USD"
                Dim conf As New configuracionPrecioProducto With
                    {
                    .idPrecio = idPrecio,
                    .descripcion = nombre,
                    .precioMN = 0,
                    .precioME = valorPrecio
                }

                listaInventario = GetInventarioUnicoV2(r, conf)
        End Select



        If listaInventario.Count > 0 Then
            Dim miInterfaz As IListaServicio = TryCast(Me.Owner, IListaServicio)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarListaServicio(listaInventario)
            'Hide()
        End If
    End Sub

    Private Function GetInventarioUnico(Record As Record, precio As configuracionPrecioProducto) As List(Of totalesAlmacen)
        '     Dim cantidadComprada As Decimal? = 0
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim obj As totalesAlmacen
        Dim cantidadDisponibleXLote As Decimal = 0
        Dim CantidadSolicitadaUM As Decimal = 0
        If (Record.GetValue("unidad") = "FOT") Then
            'formCalculoUM = New FormCalculoUM()
            'formCalculoUM.StartPosition = FormStartPosition.CenterScreen
            'formCalculoUM.Show(Me)
            Dim f As New FormCalculoUM
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, documentoventaAbarrotesDet)
                CantidadSolicitadaUM = c.importeMN
            End If

            If CantidadSolicitadaUM <= 0 Then
                Throw New Exception("Ingrese una cantidad mayor a cero")
            End If

            Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
                                                {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
                                                .idItem = Integer.Parse(Record.GetValue("idItem"))
                                                })

            Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

            If cantidadDisponible <= 0 Then
                Throw New Exception("Stock cero")
            End If

            If CantidadSolicitadaUM > cantidadDisponible Then
                '    cantidadComprada = CantidadSolicitada - cantidadDisponible
                Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
                '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
            End If

            GetInventarioUnico = New List(Of totalesAlmacen)

            If lista.Count > 0 Then
                obj = New totalesAlmacen
                obj.idEmpresa = Gempresas.IdEmpresaRuc
                obj = lista.FirstOrDefault
                obj.cantidad = CantidadSolicitadaUM
                obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
                obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote
                obj.tipoConfiguracion = precio.idPrecio
                obj.PMprecioMN = precio.precioMN
                obj.PMprecioME = precio.precioME
                obj.tipoConfiguracion = precio.idPrecio
                GetInventarioUnico.Add(obj)
            End If

        Else

            Dim CantidadSolicitada = InputBox("Ingrese cantidad de venta" & vbCrLf &
                                           precio.descripcion & vbCrLf & precio.precioMN, Record.GetValue("descripcion"), "")

            If IsNumeric(CantidadSolicitada) Then


                If CantidadSolicitada <= 0 Then
                    Throw New Exception("Ingrese una cantidad mayor a cero")
                End If


                Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
                                                    {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                    .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
                                                    .idItem = Integer.Parse(Record.GetValue("idItem"))
                                                    })

                Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

                If cantidadDisponible <= 0 Then
                    Throw New Exception("Stock cero")
                End If

                If CantidadSolicitada > cantidadDisponible Then
                    '    cantidadComprada = CantidadSolicitada - cantidadDisponible
                    Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
                    '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
                End If

                GetInventarioUnico = New List(Of totalesAlmacen)

                If lista.Count > 0 Then
                    obj = New totalesAlmacen
                    obj.idEmpresa = Gempresas.IdEmpresaRuc
                    obj = lista.FirstOrDefault
                    obj.cantidad = CantidadSolicitada
                    obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
                    obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote
                    obj.tipoConfiguracion = precio.idPrecio
                    obj.PMprecioMN = precio.precioMN
                    obj.PMprecioME = precio.precioME
                    obj.tipoConfiguracion = precio.idPrecio
                    GetInventarioUnico.Add(obj)
                End If



                'For Each i In lista
                '    cantidadDisponibleXLote = i.cantidad
                '    If CantidadSolicitada > 0 Then
                '        If i.StockSaldo > 0 Then
                '            If i.StockSaldo > CantidadSolicitada Then
                '                Dim canUso = CantidadSolicitada
                '                i.CantidadUsada = canUso

                '            ElseIf i.StockSaldo = CantidadSolicitada Then
                '                i.CantidadUsada = CantidadSolicitada
                '            Else
                '                Dim canUso = i.StockSaldo
                '                i.CantidadUsada = canUso
                '            End If
                '            CantidadSolicitada -= i.CantidadUsada 'ImporteDisponible

                '            obj = New totalesAlmacen
                '            obj = i
                '            obj.cantidad = i.CantidadUsada
                '            obj.NomAlmacen = i.NomAlmacen
                '            obj.codigoLote = i.CustomLote.codigoLote
                '            obj.cantidad2 = cantidadDisponibleXLote
                '            obj.tipoConfiguracion = precio.idPrecio
                '            obj.PMprecioMN = precio.precioMN
                '            obj.PMprecioME = precio.precioME
                '            obj.tipoConfiguracion = precio.idPrecio

                '            'If validaItem = 0 Then
                '            '    obj.CantidadComprada = cantidadComprada
                '            'Else
                '            '    obj.CantidadComprada = 0
                '            'End If
                '            GetMappingInventarioVerificado.Add(obj)
                '            '   validaItem += 1
                '        End If
                '    End If
                'Next
            Else
                Throw New Exception("Ingrese una cantidad válida")
            End If
        End If

    End Function

    Private Function GetInventarioUnicoV2(Record As Record, precio As configuracionPrecioProducto) As List(Of totalesAlmacen)
        'Dim lista2 As New List(Of totalesAlmacen)
        ''     Dim cantidadComprada As Decimal? = 0
        'Dim totalesAlmacenSA As New TotalesAlmacenSA
        'Dim obj As totalesAlmacen
        'Dim cantidadDisponibleXLote As Decimal = 0
        'Dim CantidadSolicitadaUM As Decimal = 0
        'If (Record.GetValue("unidad") = "FOT") Then
        '    'formCalculoUM = New FormCalculoUM()
        '    'formCalculoUM.StartPosition = FormStartPosition.CenterScreen
        '    'formCalculoUM.Show(Me)
        '    Dim f As New FormCalculoUM
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        '    If Not IsNothing(f.Tag) Then
        '        Dim c = CType(f.Tag, documentoventaAbarrotesDet)
        '        CantidadSolicitadaUM = c.importeMN
        '    End If

        '    If CantidadSolicitadaUM <= 0 Then
        '        Throw New Exception("Ingrese una cantidad mayor a cero")
        '    End If

        '    Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
        '                                        {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                        .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
        '                                        .idItem = Integer.Parse(Record.GetValue("idItem"))
        '                                        })

        '    Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

        '    If validaStocks = True Then
        '        If cantidadDisponible <= 0 Then
        '            Throw New Exception("Stock cero")
        '        End If

        '        If CantidadSolicitadaUM > cantidadDisponible Then
        '            '    cantidadComprada = CantidadSolicitada - cantidadDisponible
        '            Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
        '            '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
        '        End If
        '    ElseIf validaStocks = False Then

        '    End If

        '    GetInventarioUnicoV2 = New List(Of totalesAlmacen)

        '    If lista.Count > 0 Then
        '        obj = New totalesAlmacen
        '        obj.idEmpresa = Gempresas.IdEmpresaRuc
        '        obj = lista.FirstOrDefault
        '        obj.cantidad = CantidadSolicitadaUM
        '        obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
        '        obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote

        '        Select Case monedaVenta
        '            Case "SOL"
        '                obj.tipoConfiguracion = precio.idPrecio
        '                obj.PMprecioMN = precio.precioMN
        '                obj.PMprecioME = precio.precioME
        '                obj.tipoConfiguracion = precio.idPrecio

        '                obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
        '                obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
        '                obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")
        '            Case "USD"
        '                obj.tipoConfiguracion = precio.idPrecio
        '                obj.PMprecioMN = precio.precioMN
        '                obj.PMprecioME = precio.precioME
        '                obj.tipoConfiguracion = precio.idPrecio

        '                obj.montoDsctounitMenorME = Record.GetValue("pvmenorme")
        '                obj.montoDsctounitMayorME = Record.GetValue("pvmayorme")
        '                obj.montoDsctounitGMayorME = Record.GetValue("pvGmayorme")
        '        End Select
        '        GetInventarioUnicoV2.Add(obj)
        '    End If

        'Else
        '    Dim CantidadSolicitada = String.Empty
        '    'Select Case chCantidadPrevia.Checked
        '    '    Case True
        '    CantidadSolicitada = InputBox("Ingrese la cantidad a vender" & vbCrLf &
        '                                   precio.descripcion & vbCrLf & precio.precioMN, Record.GetValue("descripcion"), "")
        '    '    Case Else
        '    '        CantidadSolicitada = 1
        '    'End Select

        '    'Dim CantidadSolicitada = 1

        '    If IsNumeric(CantidadSolicitada) Then

        '        If CantidadSolicitada <= 0 Then
        '            Throw New Exception("Ingrese una cantidad mayor a cero")
        '        End If


        '        Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
        '                                            {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                            .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
        '                                            .idItem = Integer.Parse(Record.GetValue("idItem"))
        '                                            })

        '        Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

        '        If validaStocks = True Then
        '            If cantidadDisponible <= 0 Then
        '                Throw New Exception("Stock cero")
        '            End If

        '            If CantidadSolicitada > cantidadDisponible Then
        '                '    cantidadComprada = CantidadSolicitada - cantidadDisponible
        '                Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
        '                '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
        '            End If
        '        ElseIf validaStocks = False Then

        '            lista2 = totalesAlmacenSA.GetDetalleLoteXproductoProf(New totalesAlmacen With
        '                                            {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                            .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
        '                                            .idItem = Integer.Parse(Record.GetValue("idItem"))
        '                                            })

        '        End If

        '        GetInventarioUnicoV2 = New List(Of totalesAlmacen)

        '        If lista.Count > 0 Then
        '            obj = New totalesAlmacen
        '            obj.idEmpresa = Gempresas.IdEmpresaRuc
        '            obj = lista.FirstOrDefault
        '            obj.cantidad = CantidadSolicitada
        '            obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
        '            obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote
        '            Select Case monedaVenta
        '                Case "SOL"
        '                    obj.tipoConfiguracion = precio.idPrecio
        '                    obj.PMprecioMN = precio.precioMN
        '                    obj.PMprecioME = precio.precioME
        '                    obj.tipoConfiguracion = precio.idPrecio

        '                    obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
        '                    obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
        '                    obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")
        '                Case "USD"
        '                    obj.tipoConfiguracion = precio.idPrecio
        '                    obj.PMprecioMN = precio.precioMN
        '                    obj.PMprecioME = precio.precioME
        '                    obj.tipoConfiguracion = precio.idPrecio

        '                    obj.montoDsctounitMenorME = Record.GetValue("pvmenorme")
        '                    obj.montoDsctounitMayorME = Record.GetValue("pvmayorme")
        '                    obj.montoDsctounitGMayorME = Record.GetValue("pvGmayorme")
        '            End Select
        '            GetInventarioUnicoV2.Add(obj)
        '        ElseIf lista2.Count > 0 Then
        '            obj = New totalesAlmacen
        '            obj.idEmpresa = Gempresas.IdEmpresaRuc
        '            obj = lista2.FirstOrDefault
        '            obj.cantidad = CantidadSolicitada
        '            obj.NomAlmacen = lista2.FirstOrDefault.NomAlmacen
        '            obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote
        '            Select Case monedaVenta
        '                Case "SOL"
        '                    obj.tipoConfiguracion = precio.idPrecio
        '                    obj.PMprecioMN = precio.precioMN
        '                    obj.PMprecioME = precio.precioME
        '                    obj.tipoConfiguracion = precio.idPrecio

        '                    obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
        '                    obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
        '                    obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")
        '                Case "USD"
        '                    obj.tipoConfiguracion = precio.idPrecio
        '                    obj.PMprecioMN = precio.precioMN
        '                    obj.PMprecioME = precio.precioME
        '                    obj.tipoConfiguracion = precio.idPrecio

        '                    obj.montoDsctounitMenorME = Record.GetValue("pvmenorme")
        '                    obj.montoDsctounitMayorME = Record.GetValue("pvmayorme")
        '                    obj.montoDsctounitGMayorME = Record.GetValue("pvGmayorme")
        '            End Select

        '            GetInventarioUnicoV2.Add(obj)
        '        End If

        '    Else
        '        Throw New Exception("Ingrese una cantidad válida")
        '    End If
        'End If
        Dim lista2 As New List(Of totalesAlmacen)
        Dim detalleItemsSA As New servicioSA
        '     Dim cantidadComprada As Decimal? = 0
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim obj As totalesAlmacen
        Dim cantidadDisponibleXLote As Decimal = 0
        Dim CantidadSolicitadaUM As Decimal = 0
        If (Record.GetValue("unidad") = "FOT") Then
            'formCalculoUM = New FormCalculoUM()
            'formCalculoUM.StartPosition = FormStartPosition.CenterScreen
            'formCalculoUM.Show(Me)
            Dim f As New FormCalculoUM
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, documentoventaAbarrotesDet)
                CantidadSolicitadaUM = c.importeMN
            End If

            If CantidadSolicitadaUM <= 0 Then
                Throw New Exception("Ingrese una cantidad mayor a cero")
            End If

            'Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
            '                                    {.idEmpresa = Gempresas.IdEmpresaRuc,
            '                                    .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
            '                                    .idItem = Integer.Parse(Record.GetValue("idItem"))
            '                                    })

            'Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

            'If validaStocks = True Then
            '    If cantidadDisponible <= 0 Then
            '        Throw New Exception("Stock cero")
            '    End If

            '    If CantidadSolicitadaUM > cantidadDisponible Then
            '        '    cantidadComprada = CantidadSolicitada - cantidadDisponible
            '        Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
            '        '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
            '    End If
            'ElseIf validaStocks = False Then

            'End If
            GetInventarioUnicoV2 = New List(Of totalesAlmacen)
            Dim t = detalleItemsSA.GetUbicaServicioID(Record.GetValue("idItem"))

            cantidadDisponibleXLote = 0
            If CantidadSolicitadaUM > 0 Then

                obj = New totalesAlmacen
                obj.idEmpresa = t.idEmpresa
                obj.idEstablecimiento = t.idEstablecimiento
                obj.idItem = t.idServicio
                obj.descripcion = t.descripcion
                'obj.origenRecaudo = t.origenProducto
                obj.cantidad = CantidadSolicitadaUM
                obj.tipoExistencia = t.tipoExist
                'obj.idUnidad = t.unidadMedida
                obj.unidadMedida = t.unidadMedida
                obj.NomAlmacen = "-"
                obj.codigoLote = 0
                obj.cantidad2 = cantidadDisponibleXLote
                obj.tipoConfiguracion = precio.idPrecio
                obj.PMprecioMN = precio.precioMN
                obj.PMprecioME = precio.precioME
                obj.tipoConfiguracion = precio.idPrecio

                GetInventarioUnicoV2.Add(obj)
                'GetMappingInventarioVerificadoSinControl = obj
            Else
                Throw New Exception("Ingrese una cantidad válida")
            End If

            'GetInventarioUnicoV2 = New List(Of totalesAlmacen)

            'If lista.Count > 0 Then
            '    obj = New totalesAlmacen
            '    obj.idEmpresa = Gempresas.IdEmpresaRuc
            '    obj = lista.FirstOrDefault
            '    obj.cantidad = CantidadSolicitadaUM
            '    obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
            '    obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote

            ''Select Case monedaVenta
            ''    Case "SOL"
            'obj.tipoConfiguracion = precio.idPrecio
            '        obj.PMprecioMN = precio.precioMN
            '        obj.PMprecioME = precio.precioME
            '        obj.tipoConfiguracion = precio.idPrecio

            '        obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
            '        obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
            '        obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")
            ''    Case "USD"
            ''        obj.tipoConfiguracion = precio.idPrecio
            ''        obj.PMprecioMN = precio.precioMN
            ''        obj.PMprecioME = precio.precioME
            ''        obj.tipoConfiguracion = precio.idPrecio

            ''        obj.montoDsctounitMenorME = Record.GetValue("pvmenorme")
            ''        obj.montoDsctounitMayorME = Record.GetValue("pvmayorme")
            ''        obj.montoDsctounitGMayorME = Record.GetValue("pvGmayorme")
            ''End Select
            'GetInventarioUnicoV2.Add(obj)
            'End If

        Else
            Dim CantidadSolicitada = String.Empty
            'Select Case chCantidadPrevia.Checked
            '    Case True
            CantidadSolicitada = InputBox("Ingrese la cantidad a vender" & vbCrLf &
                                           precio.descripcion & vbCrLf & precio.precioMN, Record.GetValue("descripcion"), "")
            '    Case Else
            '        CantidadSolicitada = 1
            'End Select

            'Dim CantidadSolicitada = 1

            If IsNumeric(CantidadSolicitada) Then

                If CantidadSolicitada <= 0 Then
                    Throw New Exception("Ingrese una cantidad mayor a cero")
                End If


                '    Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
                '                                        {.idEmpresa = Gempresas.IdEmpresaRuc,
                '                                        .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
                '                                        .idItem = Integer.Parse(Record.GetValue("idItem"))
                '                                        })

                '    Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

                '    If validaStocks = True Then
                '        If cantidadDisponible <= 0 Then
                '            Throw New Exception("Stock cero")
                '        End If

                '        If CantidadSolicitada > cantidadDisponible Then
                '            '    cantidadComprada = CantidadSolicitada - cantidadDisponible
                '            Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
                '            '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
                '        End If
                '    ElseIf validaStocks = False Then

                '        lista2 = totalesAlmacenSA.GetDetalleLoteXproductoProf(New totalesAlmacen With
                '                                        {.idEmpresa = Gempresas.IdEmpresaRuc,
                '                                        .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
                '                                        .idItem = Integer.Parse(Record.GetValue("idItem"))
                '                                        })

                '    End If

                '    GetInventarioUnicoV2 = New List(Of totalesAlmacen)

                '    If lista.Count > 0 Then
                '        obj = New totalesAlmacen
                '        obj.idEmpresa = Gempresas.IdEmpresaRuc
                '        obj = lista.FirstOrDefault
                '        obj.cantidad = CantidadSolicitada
                '        obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
                '        obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote
                '        'Select Case monedaVenta
                '        '    Case "SOL"
                '        obj.tipoConfiguracion = precio.idPrecio
                '                obj.PMprecioMN = precio.precioMN
                '                obj.PMprecioME = precio.precioME
                '                obj.tipoConfiguracion = precio.idPrecio

                '                obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
                '                obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
                '                obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")
                '        '    Case "USD"
                '        '        obj.tipoConfiguracion = precio.idPrecio
                '        '        obj.PMprecioMN = precio.precioMN
                '        '        obj.PMprecioME = precio.precioME
                '        '        obj.tipoConfiguracion = precio.idPrecio

                '        '        obj.montoDsctounitMenorME = Record.GetValue("pvmenorme")
                '        '        obj.montoDsctounitMayorME = Record.GetValue("pvmayorme")
                '        '        obj.montoDsctounitGMayorME = Record.GetValue("pvGmayorme")
                '        'End Select
                '        GetInventarioUnicoV2.Add(obj)
                '    ElseIf lista2.Count > 0 Then
                '        obj = New totalesAlmacen
                '        obj.idEmpresa = Gempresas.IdEmpresaRuc
                '        obj = lista2.FirstOrDefault
                '        obj.cantidad = CantidadSolicitada
                '        obj.NomAlmacen = lista2.FirstOrDefault.NomAlmacen
                '        obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote
                '        'Select Case monedaVenta
                '        '    Case "SOL"
                '        obj.tipoConfiguracion = precio.idPrecio
                '                obj.PMprecioMN = precio.precioMN
                '                obj.PMprecioME = precio.precioME
                '                obj.tipoConfiguracion = precio.idPrecio

                '                obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
                '                obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
                '                obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")
                '        '    Case "USD"
                '        '        obj.tipoConfiguracion = precio.idPrecio
                '        '        obj.PMprecioMN = precio.precioMN
                '        '        obj.PMprecioME = precio.precioME
                '        '        obj.tipoConfiguracion = precio.idPrecio

                '        '        obj.montoDsctounitMenorME = Record.GetValue("pvmenorme")
                '        '        obj.montoDsctounitMayorME = Record.GetValue("pvmayorme")
                '        '        obj.montoDsctounitGMayorME = Record.GetValue("pvGmayorme")
                '        'End Select

                '        GetInventarioUnicoV2.Add(obj)
                '    End If

                'Else
                '    Throw New Exception("Ingrese una cantidad válida")
                'End If

                GetInventarioUnicoV2 = New List(Of totalesAlmacen)
                Dim t = detalleItemsSA.GetUbicaServicioID(Record.GetValue("idItem"))

                cantidadDisponibleXLote = 0
                If CantidadSolicitada > 0 Then

                    obj = New totalesAlmacen
                    obj.idEmpresa = t.idEmpresa
                    obj.idEstablecimiento = t.idEstablecimiento
                    obj.idItem = t.idServicio
                    obj.descripcion = t.descripcion
                    'obj.origenRecaudo = t.origenProducto
                    obj.cantidad = CantidadSolicitada
                    obj.tipoExistencia = t.tipoExist
                    'obj.idUnidad = t.unidad1
                    obj.unidadMedida = t.unidadMedida
                    obj.NomAlmacen = "-"
                    obj.codigoLote = 0
                    obj.cantidad2 = CantidadSolicitada
                    obj.idUnidad = t.unidadMedida
                    obj.origenRecaudo = t.codigo
                    obj.tipoConfiguracion = precio.idPrecio
                    obj.PMprecioMN = precio.precioMN
                    obj.PMprecioME = precio.precioME
                    obj.tipoConfiguracion = precio.idPrecio

                    obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
                    obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
                    obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")

                    GetInventarioUnicoV2.Add(obj)
                    'GetMappingInventarioVerificadoSinControl = obj
                Else
                    Throw New Exception("Ingrese una cantidad válida")
                End If

            End If
        End If
    End Function

#End Region

    Private Sub GetproductoSelect(idPrecio As Integer, nombre As String, valorPrecio As Decimal)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim sa As New TotalesAlmacenSA
        Dim r As Record
        r = GridTotales.Table.CurrentRecord
        'Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))

        If valorPrecio <= 0 Then
            MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim conf As New configuracionPrecioProducto With
        {
        .idPrecio = idPrecio,
        .descripcion = nombre,
        .precioMN = valorPrecio,
        .precioME = 0
        }

        Dim listaInventario = GetMappingInventarioVerificado(r, conf)

        If listaInventario.Count > 0 Then
            Dim miInterfaz As IListaInventario = TryCast(Me.Owner, IListaInventario)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarListaArticulos(listaInventario)
        End If
    End Sub

    Private Sub GetproductoSelectSinControl(idPrecio As Integer, nombre As String, valorPrecio As Decimal)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim sa As New TotalesAlmacenSA
        Dim r As Record
        r = GridTotales.Table.CurrentRecord
        'Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))

        Dim conf As New configuracionPrecioProducto With
        {
        .idPrecio = idPrecio,
        .descripcion = nombre,
        .precioMN = valorPrecio,
        .precioME = 0
        }

        Dim listaInventario = GetMappingInventarioVerificadoSinControl(r, conf)

        If listaInventario IsNot Nothing Then
            Dim miInterfaz As IForm = TryCast(Me.Owner, IForm)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarProducto(listaInventario)
        End If
    End Sub

    Private Function GetMappingInventarioVerificado(Record As Record, precio As configuracionPrecioProducto) As List(Of totalesAlmacen)
        '     Dim cantidadComprada As Decimal? = 0
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim obj As totalesAlmacen
        Dim cantidadDisponibleXLote As Decimal = 0

        Dim CantidadSolicitada = InputBox("Ingrese cantidad de venta" & vbCrLf &
                                           precio.descripcion & vbCrLf & precio.precioMN, Record.GetValue("descripcion"), "")

        If IsNumeric(CantidadSolicitada) Then


            If CantidadSolicitada <= 0 Then
                Throw New Exception("Ingrese una cantidad mayor a cero")
            End If


            Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
                                                {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
                                                .idItem = Integer.Parse(Record.GetValue("idItem"))
                                                })

            Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

            If cantidadDisponible <= 0 Then
                Throw New Exception("Stock cero")
            End If

            If CantidadSolicitada > cantidadDisponible Then
                '    cantidadComprada = CantidadSolicitada - cantidadDisponible
                Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
                '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
            End If

            GetMappingInventarioVerificado = New List(Of totalesAlmacen)
            'If lista.Count > 0 Then
            '    If cantidadComprada > 0 Then
            '        lista(0).cantidad = lista(0).cantidad + cantidadComprada
            '    End If
            'End If
            '   Dim validaItem As Integer = 0
            For Each i In lista
                cantidadDisponibleXLote = i.cantidad
                If CantidadSolicitada > 0 Then
                    If i.StockSaldo > 0 Then
                        If i.StockSaldo > CantidadSolicitada Then
                            Dim canUso = CantidadSolicitada
                            i.CantidadUsada = canUso

                        ElseIf i.StockSaldo = CantidadSolicitada Then
                            i.CantidadUsada = CantidadSolicitada
                        Else
                            Dim canUso = i.StockSaldo
                            i.CantidadUsada = canUso
                        End If
                        CantidadSolicitada -= i.CantidadUsada 'ImporteDisponible

                        obj = New totalesAlmacen
                        obj = i
                        obj.cantidad = i.CantidadUsada
                        obj.NomAlmacen = i.NomAlmacen
                        obj.codigoLote = i.CustomLote.codigoLote
                        obj.cantidad2 = cantidadDisponibleXLote
                        obj.tipoConfiguracion = precio.idPrecio
                        obj.PMprecioMN = precio.precioMN
                        obj.PMprecioME = precio.precioME
                        obj.tipoConfiguracion = precio.idPrecio

                        'If validaItem = 0 Then
                        '    obj.CantidadComprada = cantidadComprada
                        'Else
                        '    obj.CantidadComprada = 0
                        'End If
                        GetMappingInventarioVerificado.Add(obj)
                        '   validaItem += 1
                    End If
                End If
            Next
        Else
            Throw New Exception("Ingrese una cantidad válida")
        End If
    End Function
    Private Function GetMappingInventarioVerificadoSinControl(Record As Record, precio As configuracionPrecioProducto) As totalesAlmacen
        GetMappingInventarioVerificadoSinControl = New totalesAlmacen
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim obj As totalesAlmacen
        Dim detalleItemsSA As New detalleitemsSA
        Dim cantidadDisponibleXLote As Decimal = 0
        Dim CantidadSolicitada = String.Empty
        CantidadSolicitada = InputBox("Ingrese cantidad de venta" & vbCrLf &
                                           precio.descripcion & vbCrLf & precio.precioMN, Record.GetValue("descripcion"), "")

        If IsNumeric(CantidadSolicitada) Then

            'Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
            '                                    {.idEmpresa = Gempresas.IdEmpresaRuc,
            '                                    .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
            '                                    .idItem = Integer.Parse(Record.GetValue("idItem"))
            '                                    })

            Dim t = detalleItemsSA.InvocarProductoID(Record.GetValue("idItem"))
            cantidadDisponibleXLote = 0
            If CantidadSolicitada > 0 Then
                obj = New totalesAlmacen
                obj.idEmpresa = t.idEmpresa
                obj.idEstablecimiento = t.idEstablecimiento
                obj.idItem = t.codigodetalle
                obj.descripcion = t.descripcionItem
                obj.origenRecaudo = t.origenProducto
                obj.cantidad = CantidadSolicitada
                obj.tipoExistencia = t.tipoExistencia
                obj.idUnidad = t.unidad1
                obj.unidadMedida = t.unidad1
                obj.NomAlmacen = "-"
                obj.codigoLote = 0
                obj.cantidad2 = cantidadDisponibleXLote
                obj.tipoConfiguracion = precio.idPrecio
                obj.PMprecioMN = precio.precioMN
                obj.PMprecioME = precio.precioME
                obj.tipoConfiguracion = precio.idPrecio
                obj.montoDsctounitMenorMN = Record.GetValue("pvmenor")
                obj.montoDsctounitMayorMN = Record.GetValue("pvmayor")
                obj.montoDsctounitGMayorMN = Record.GetValue("pvGmayor")
                GetMappingInventarioVerificadoSinControl = obj
            Else
                Throw New Exception("Ingrese una cantidad válida")
            End If


        End If
    End Function


    Private Sub GridTotales_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellDoubleClick
        Try
            'If chCantidadPrevia.Checked = False Then
            If GridTotales.Table.SelectedRecords.Count > 0 Then
                Dim precioMenor = Decimal.Parse(GridTotales.Table.CurrentRecord.GetValue("pvmenor"))
                GetproductoUnicoV2(1, "Precio por Menor", precioMenor)
            End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridTotales.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            ElseIf e.Inner.ColIndex = 5 Then ' menor dolares
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

            ElseIf e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
            ElseIf e.Inner.ColIndex = 7 Then 'mayor dolares
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
            ElseIf e.Inner.ColIndex = 8 Then
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
            ElseIf e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
            End If
        End If
    End Sub
    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTotales.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try

            If e.Inner.ColIndex = 5 Then 'menor soles
                Dim precioMenor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 5).CellValue)
                'If validaStocks = True Then
                '          GetproductoSelect(1, "Precio por Menor", precioMenor)
                'GetproductoUnico(1, "Precio por Menor", precioMenor)

                GetproductoUnicoV2(1, "Precio por Menor", precioMenor)
                'Else
                '    GetproductoSelectSinControl(1, "Precio por Menor", precioMenor)
                'End If

            ElseIf e.Inner.ColIndex = 7 Then 'menor dolares
                Dim precioMenorME = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 7).CellValue)
                'If validaStocks = True Then
                '          GetproductoSelect(1, "Precio por Menor", precioMenor)
                'GetproductoUnico(1, "Precio por Menor", precioMenor)

                GetproductoUnicoV2(1, "Precio por Menor", precioMenorME)

            ElseIf e.Inner.ColIndex = 9 Then 'mayor soles
                Dim precioMayorMN = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 9).CellValue)
                'If validaStocks = True Then
                'GetproductoSelect(2, "Precio por Mayor", precioMayor)
                '  GetproductoUnico(2, "Precio por Mayor", precioMayor)
                GetproductoUnicoV2(2, "Precio por Mayor", precioMayorMN)
                'Else
                '    GetproductoSelectSinControl(2, "Precio por Mayor", precioMayor)
                'End If
            ElseIf e.Inner.ColIndex = 10 Then 'mayor dolares
                Dim precioMayorME = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 10).CellValue)
                GetproductoUnicoV2(2, "Precio por Mayor", precioMayorME)

            ElseIf e.Inner.ColIndex = 11 Then 'gran mayor soles
                Dim precioGranMayor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 11).CellValue)
                'If validaStocks = True Then
                'GetproductoSelect(3, "Precio por Gran Mayor", precioGranMayor)
                '   GetproductoUnico(3, "Precio por Gran Mayor", precioGranMayor)
                GetproductoUnicoV2(3, "Precio por Gran Mayor", precioGranMayor)
                'Else
                '    GetproductoSelectSinControl(3, "Precio por Gran Mayor", precioGranMayor)
                'End If
            ElseIf e.Inner.ColIndex = 12 Then 'gran mayor dolares
                Dim precioGranMayorME = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 12).CellValue)
                'If validaStocks = True Then
                'GetproductoSelect(3, "Precio por Gran Mayor", precioGranMayor)
                '   GetproductoUnico(3, "Precio por Gran Mayor", precioGranMayor)
                GetproductoUnicoV2(3, "Precio por Gran Mayor", precioGranMayorME)
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Atención")
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs)


    End Sub
#End Region

    Private Sub Grabar(cantComprada As Decimal)
        Dim entidadSA As New entidadSA
        Dim CompraSA As New DocumentoCompraSA
        Dim FormatoFecha = DateTime.Now

        Dim ImporteTotalCompras As Decimal = 0
        Dim prov = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, Nothing, GEstableciento.IdEstablecimiento)


        Dim numeroNota = CompraSA.GetNumeracionCompra(New documentocompra With
                                            {
                                            .idEmpresa = Gempresas.IdEmpresaRuc,
                                            .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA
                                                      })

        Dim be As New documento With
        {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = "9907",
        .fechaProceso = FormatoFecha,
        .moneda = "1",
        .idEntidad = prov.idEntidad,
        .entidad = prov.nombreCompleto,
        .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR,
        .nrodocEntidad = "-",
        .nroDoc = numeroNota,
        .tipoOperacion = StatusTipoOperacion.COMPRA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        be.documentocompra = New documentocompra With
        {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_COMPRAS,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaLaboral = DateTime.Now,
        .fechaDoc = FormatoFecha,
        .fechaContable = GetPeriodo(FormatoFecha, True),
        .tipoDoc = "9907",
        .serie = "NOTE",
        .numeroDoc = numeroNota,
        .idProveedor = prov.idEntidad,
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
        .destino = TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
        .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
        .glosa = "Por la compra según nota de compra",
        .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
        .situacion = statusComprobantes.Normal,
        .tieneDetraccion = "N",
        .usuarioActualizacion = usuario.IDUsuario.ToString,
        .fechaActualizacion = DateTime.Now
        }

        be.documentocompra.documentocompradetalle = GetDetalleNota(be, GridTotales.Table.CurrentRecord, cantComprada)
        CompraSA.GrabarNotaCompraDirecta(be)
        MsgBox("Compra realizada", MsgBoxStyle.Information, "Atención")
        'If VentanaSel IsNot Nothing Then
        '    VentanaSel.ThreadTransito()
        'End If
        '      Close()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ndocumento"></param>
    ''' <returns></returns>
    Private Function GetDetalleNota(ndocumento As documento, r As Record, cantidadComprada As Decimal) As List(Of documentocompradetalle)
        GetDetalleNota = New List(Of documentocompradetalle)
        Dim nroLotex = Nothing
        Dim obj As recursoCostoLote = Nothing
        Dim objDetalle As documentocompradetalle
        '  For Each i In dgvCompra.Table.Records
        objDetalle = New documentocompradetalle
        ndocumento.documentocompra.AsigancionDeLotes = "POR LOTES"
        nroLotex = "-"
        obj = New recursoCostoLote With
                            {
                            .fechaentrada = ndocumento.fechaProceso,
                            .nroLote = nroLotex,
                            .detalle = r.GetValue("descripcion"),
                            .fechaProduccion = Date.Now,
                            .productoSustentado = False
                            }
        Dim precios As New List(Of configuracionPrecioProducto)


        objDetalle = New documentocompradetalle With
                               {
                               .ItemEntregadototal = "S",
                               .nrolote = nroLotex,
                               .CustomRecursoCostoLote = obj,
                               .IdEmpresa = Gempresas.IdEmpresaRuc,
                               .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                               .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                               .TipoOperacion = StatusTipoOperacion.COMPRA,
                               .FechaDoc = ndocumento.fechaProceso,
                               .FechaLaboral = DateTime.Now,
                               .CuentaProvedor = "4212",
                               .NombreProveedor = "Varios",
                               .Serie = "NT",
                               .NumDoc = ndocumento.nroDoc,
                               .TipoDoc = ndocumento.tipoDoc,
                               .idItem = r.GetValue("idItem"),
                               .descripcionItem = r.GetValue("descripcion"),
                               .tipoExistencia = TipoExistencia.Mercaderia,
                               .destino = r.GetValue("destino"),
                               .unidad1 = r.GetValue("unidad"),
                               .monto1 = cantidadComprada,
                               .precioUnitario = 0,
                               .precioUnitarioUS = 0,
                               .importe = 0,
                               .importeUS = 0,
                               .montokardex = 0,
                               .montoIsc = 0,
                               .montoIgv = 0,
                               .otrosTributos = 0,
                               .montokardexUS = 0,
                               .montoIscUS = 0,
                               .montoIgvUS = 0,
                               .otrosTributosUS = 0,
                               .almacenRef = Integer.Parse(r.GetValue("idalmacen")),
                               .fechaEntrega = DateTime.Now,
                               .estadoPago = "PN",
                               .usuarioModificacion = usuario.IDUsuario,
                               .fechaModificacion = DateTime.Now
                               }
        'objDetalle.CustomInventarioMovimiento = GetInventario(objDetalle)
        GetDetalleNota.Add(objDetalle)
        '    Next
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

        'Try
        '    Select Case Me.TabControlAdv1.SelectedIndex
        '        Case 0
        '            Dim r As Record = GridTotales.Table.CurrentRecord
        '            If r IsNot Nothing Then
        '                Dim nombreProducto As String = r.GetValue("descripcion")
        '                txtFiltrar.Text = nombreProducto
        '                Dim CantidadSolicitada = InputBox("Ingrese cantidad a comprar" & vbCrLf &
        '                                               r.GetValue("descripcion"), "")
        '                If IsNumeric(CantidadSolicitada) Then
        '                    If CantidadSolicitada > 0 Then
        '                        Grabar(CantidadSolicitada)
        '                        ObtenerCanastaVentaFiltro("01", txtFiltrar.Text.Trim)
        '                    Else
        '                        MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    End If
        '                Else
        '                    MessageBox.Show("Debe ingresar un número valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                End If
        '            End If

        '        Case 1
        '            ''productos sin almacen codigo aqui
        '            'Dim r As Record = GridSinAlmacen.Table.CurrentRecord
        '            'If r IsNot Nothing Then
        '            '    Dim nombreProducto As String = r.GetValue("descripcion")
        '            '    txtFiltrar.Text = nombreProducto
        '            '    Dim f As New FormCompraRapida(New detalleitems With
        '            '                          {
        '            '                          .codigodetalle = r.GetValue("idItem"),
        '            '                          .descripcionItem = r.GetValue("descripcion")
        '            '                          })
        '            '    f.TextCantidad.DecimalValue = 1
        '            '    f.StartPosition = FormStartPosition.CenterScreen
        '            '    f.ShowDialog(Me)
        '            '    'threadArticulosSinAlmacen()
        '            '    ObtenerCanastaVentaFiltro("01", txtFiltrar.Text.Trim)
        '            'Else
        '            '    MessageBox.Show("Debe seleccionat producto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            'End If
        '    End Select


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub TextCodigoBarra_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoBarra.TextChanged

    End Sub

    Private Sub txtCodigoBarra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextCodigoBarra.KeyPress
        Me.Cursor = Cursors.WaitCursor
        'txtCodigoBarra.Clear()
        If Char.IsDigit(e.KeyChar) Then
            TextCodigoBarra.Select(TextCodigoBarra.Text.Length, 0)

            e.Handled = False
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            'Como se sabe los lectores de barra al final mandan un {ENTER}
            'por eso una vez que lo envía aqui se haces la función que deseas realizar
            e.Handled = True
            If TextCodigoBarra.Text.Trim.Length > 0 Then
                ObtenerCanastaVentaFiltroCodigo(TipoExistencia.Mercaderia, TextCodigoBarra.Text.Trim)
            End If
        Else
            '  e.Handled = True

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextCodigoBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoBarra.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Dim tipoMercaderia As String = "01"
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextCodigoBarra.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)

                ObtenerCanastaVentaFiltroCodigo(tipoMercaderia, TextCodigoBarra.Text.Trim)
                '  lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
            Else
                '   lblEstado.Text = "Digitar un producto válido!"
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Panellotes.Visible = True Then
            Panellotes.Visible = False
        Else
            Panellotes.Visible = True
        End If
    End Sub

    Private Sub ChFiltro2_OnChange(sender As Object, e As EventArgs) Handles ChFiltro2.OnChange
        If ChFiltro2.Checked = True Then
            txtFiltrar.Clear()
            GridTotales.Table.Records.DeleteAll()
            txtFiltrar.Select()
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim F As New FormVentaBusquedaAvanzada
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog(Me)
    End Sub

    Private Sub FormInventarioCanastaTotales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FormatoGridAvanzado(GridTotales, False, False, 12)
        'Select Case Gempresas.IdEmpresaRuc
        '    Case "20486529131" 'mas pernos
        'chCantidadPrevia.Checked = True
        'chCantidadPrevia.Visible = False
        '    Case Else
        '        chCantidadPrevia.Checked = False
        ToolStripComboBox1.Text = "PRECIOS 2 DIGITOS"
        ToolStripComboBox1.Size = New Size(160, 21)
        'End Select
        Me.TabControlAdv1.SelectedIndex = 0

        Select Case monedaVenta
            Case "SOL"
                TabControlAdv1.TabPages(0).Text = "Productos para venta en soles"
            Case "USD"
                TabControlAdv1.TabPages(0).Text = "Productos para venta en doláres"
        End Select

    End Sub

    Public Sub BusquedaAvanzadaProductos(be As BusquedaAvanzadaProductos) Implements IBusquedaAvanzadaProductos.BusquedaAvanzadaProductos
        If be IsNot Nothing Then
            Select Case be.tipo
                Case "MARCA"
                    BuscarXMarca(TipoExistencia.Mercaderia, be.codigo)
                Case "CLASIFICACION"
                    BuscarXGrupo(TipoExistencia.Mercaderia, be.codigo)
            End Select
        End If
    End Sub

    Private Sub BuscarXGrupo(tipoExistencia As String, idcat As Integer)
        ObtenerCanastaVentaGRUPO(tipoExistencia, idcat)
    End Sub

    Private Sub BuscarXMarca(tipoExistencia As String, marca As String)
        ObtenerCanastaVentaMarca(tipoExistencia, marca)
    End Sub

    Private Sub chCantidadPrevia_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtFiltrar_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtFiltrar.MouseDoubleClick
        txtFiltrar.SelectAll()
    End Sub

    Private Sub FormInventarioCanastaTotales_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            GridTotales.Table.Records.DeleteAll()
            txtFiltrar.Clear()
            Me.Close()
        ElseIf (e.KeyCode = Keys.F1) Then
            ToolStripButton5.PerformClick()
        ElseIf (e.KeyCode = Keys.F2) Then
            ToolStripButton4.PerformClick()
        ElseIf (e.KeyCode = Keys.F3) Then
            If ChFiltro2.Checked = True Then
                txtFiltrar.Clear()
                GridTotales.Table.Records.DeleteAll()
                txtFiltrar.Select()
            End If
        End If
    End Sub

    Private Sub FormInventarioCanastaTotales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If thread IsNot Nothing Then
            thread.Abort()
        End If
    End Sub

    Private Sub FormInventarioCanastaTotales_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtFiltrar.Select()
    End Sub

    Private Sub FormInventarioCanastaTotales_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If GridTotales.Table.Records.Count > 0 Then
            'GridTotales.Focus()
            'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).SetCurrent()
            'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).BeginEdit()
        End If
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        'Select Case ToolStripComboBox1.Text
        '    Case "PRECIOS 2 DIGITOS"
        '        With GridTotales.TableDescriptor.Columns("pvmenor").Appearance.AnyRecordFieldCell.CurrencyEdit
        '            .CurrencyDecimalDigits = 2
        '        End With

        '        With GridTotales.TableDescriptor.Columns("pvmayor").Appearance.AnyRecordFieldCell.CurrencyEdit
        '            .CurrencyDecimalDigits = 2
        '        End With

        '        With GridTotales.TableDescriptor.Columns("pvmayorme").Appearance.AnyRecordFieldCell.CurrencyEdit
        '            .CurrencyDecimalDigits = 2
        '        End With
        '    Case "PRECIOS 5 DIGITOS"
        '        With GridTotales.TableDescriptor.Columns("pvmenor").Appearance.AnyRecordFieldCell.CurrencyEdit
        '            .CurrencyDecimalDigits = 5
        '        End With

        '        With GridTotales.TableDescriptor.Columns("pvmayor").Appearance.AnyRecordFieldCell.CurrencyEdit
        '            .CurrencyDecimalDigits = 5
        '        End With

        '        With GridTotales.TableDescriptor.Columns("pvmayorme").Appearance.AnyRecordFieldCell.CurrencyEdit
        '            .CurrencyDecimalDigits = 5
        '        End With
        'End Select
    End Sub

    Private Sub GridTotales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridTotales.QueryCellStyleInfo
        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            If e.TableCellIdentity.Column.MappingName = "pvmenor" Then
                Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    Dim r As Record = el.GetRecord()
                    If r Is Nothing Then Return
                    Dim PrecioVenta As Decimal? = r.GetValue("pvmenor")

                    If IsNumeric(PrecioVenta) Then
                        Select Case ToolStripComboBox1.Text
                            Case "PRECIOS 2 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
                            Case "PRECIOS 5 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
                        End Select
                    End If
                End If
            ElseIf e.TableCellIdentity.Column.MappingName = "pvmayor" Then
                Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    Dim r As Record = el.GetRecord()
                    If r Is Nothing Then Return
                    Dim PrecioVenta As Decimal? = r.GetValue("pvmayor")

                    If IsNumeric(PrecioVenta) Then
                        Select Case ToolStripComboBox1.Text
                            Case "PRECIOS 2 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
                            Case "PRECIOS 5 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
                        End Select
                    End If
                End If
            ElseIf e.TableCellIdentity.Column.MappingName = "pvGmayor" Then
                Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    Dim r As Record = el.GetRecord()
                    If r Is Nothing Then Return
                    Dim PrecioVenta As Decimal? = r.GetValue("pvGmayor")

                    If IsNumeric(PrecioVenta) Then
                        Select Case ToolStripComboBox1.Text
                            Case "PRECIOS 2 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
                            Case "PRECIOS 5 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
                        End Select
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub GridSinAlmacen_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub GridSinAlmacen_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        'If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
        '    If e.TableCellIdentity.Column.MappingName = "pvmenor" Then
        '        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
        '        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
        '            Dim r As Record = el.GetRecord()
        '            If r Is Nothing Then Return
        '            Dim PrecioVenta As Decimal? = r.GetValue("pvmenor")

        '            If IsNumeric(PrecioVenta) Then
        '                Select Case ToolStripComboBox1.Text
        '                    Case "PRECIOS 2 DIGITOS"
        '                        e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
        '                    Case "PRECIOS 5 DIGITOS"
        '                        e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
        '                End Select
        '            End If
        '        End If
        '    ElseIf e.TableCellIdentity.Column.MappingName = "pvmayor" Then
        '        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
        '        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
        '            Dim r As Record = el.GetRecord()
        '            If r Is Nothing Then Return
        '            Dim PrecioVenta As Decimal? = r.GetValue("pvmayor")

        '            If IsNumeric(PrecioVenta) Then
        '                Select Case ToolStripComboBox1.Text
        '                    Case "PRECIOS 2 DIGITOS"
        '                        e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
        '                    Case "PRECIOS 5 DIGITOS"
        '                        e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
        '                End Select
        '            End If
        '        End If
        '    ElseIf e.TableCellIdentity.Column.MappingName = "pvGmayor" Then
        '        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
        '        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
        '            Dim r As Record = el.GetRecord()
        '            If r Is Nothing Then Return
        '            Dim PrecioVenta As Decimal? = r.GetValue("pvGmayor")

        '            If IsNumeric(PrecioVenta) Then
        '                Select Case ToolStripComboBox1.Text
        '                    Case "PRECIOS 2 DIGITOS"
        '                        e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
        '                    Case "PRECIOS 5 DIGITOS"
        '                        e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
        '                End Select
        '            End If
        '        End If
        '    End If
        'End If
    End Sub


    Private Sub RoundButton21_Click_1(sender As Object, e As EventArgs)
        Dim almacen As New List(Of almacen)
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor

        With FormNuevoProductoConPrecios
            .TextMenor.Enabled = True
            .TextMayor.Enabled = True
            .TextGmayor.Enabled = True
            If txtFiltrar.Text.Trim.Length > 0 Then
                .txtProductoNew.Text = txtFiltrar.Text.Trim
            End If
            If Gempresas.Regimen = "1" Then
                .cboIgv.Text = "1 - GRAVADO"
                .cboIgv.Enabled = True
            Else
                .cboIgv.Text = "2 - EXONERADO"
                .cboIgv.Enabled = True
            End If
            .cboUnidades.Text = "UNIDAD (BIENES)"
            .chClasificacion.Checked = False
            .cboTipoExistencia.SelectedValue = "01"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' dfgfg
                ' GetItems(txtFiltrar.Text.Trim)
                ' fsdf
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim almacen As New List(Of almacen)
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor

        With FormNuevoServicioConPrecios
            .TextMenor.Enabled = True
            .TextMayor.Enabled = True
            .TextGmayor.Enabled = True
            .cboTipoExistencia.SelectedValue = TipoExistencia.ServicioGasto
            If txtFiltrar.Text.Trim.Length > 0 Then
                .txtProductoNew.Text = txtFiltrar.Text.Trim
            End If
            If Gempresas.Regimen = "1" Then
                .cboIgv.Text = "1 - GRAVADO"
                .cboIgv.Enabled = True
            Else
                .cboIgv.Text = "2 - EXONERADO"
                .cboIgv.Enabled = True
            End If
            .cboUnidades.Text = "UNIDAD (BIENES)"
            .chClasificacion.Checked = False
            .cboTipoExistencia.SelectedValue = "GS"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' dfgfg
                ' GetItems(txtFiltrar.Text.Trim)
                ' fsdf
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class