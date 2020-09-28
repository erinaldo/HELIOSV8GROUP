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
Imports Syncfusion.GridHelperClasses
Public Class FormCanastaTotalesServVer2
    Private idAlmacen As Integer
    Public Property validaStocks() As Boolean
#Region "Attributes"
    Public Property validaSelPrecioVenta() As Boolean
#End Region

#Region "Constructors"
    Public Sub New(id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'GridCFG(GridTotales)
        FormatoGridAvanzado(GridTotales, False, False)
        idAlmacen = id
    End Sub

    Public Sub New(id As Integer, producto As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'GridCFG(GridTotales)
        FormatoGridAvanzado(GridTotales, False, False)
        idAlmacen = id
        txtFiltrar.Text = producto
        ObtenerCanastaVentaFiltro("01", txtFiltrar.Text.Trim)
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GridCFG(GridTotales)
    End Sub
#End Region

#Region "Methods"
    Private Sub ObtenerCanastaVentaFiltroCodigo(strTipoExistencia As String, strProducto As String)
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

            For Each i As totalesAlmacen In CanastaSA.GetInventarioParaVentaAcumuladoCodigo(
                New totalesAlmacen With
                {
                .idAlmacen = idAlmacen,
                .tipoExistencia = strTipoExistencia,
                .descripcion = strProducto,
                .NomAlmacen = ""
                })
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
            Dim fchooser As FieldChooser = New FieldChooser(GridTotales)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub ObtenerCanastaVentaFiltro(strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios
        Dim objAlmacen As New totalesAlmacen
        Dim articulosSA As New detalleitemsSA
        Dim dt As New DataTable()
        Dim TipoExistencia() As String = {Constantes.TipoExistencia.Mercaderia, Constantes.TipoExistencia.ProductoTerminado, Constantes.TipoExistencia.SubProductosDesechos}
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
            Dim products = ItemSA.GetArticulosSinAlmacenSearchText(General.Gempresas.IdEmpresaRuc, strProducto)
            'For Each i As detalleitems In articulosSA.GetExistenciasByempresaNombreFull(Gempresas.IdEmpresaRuc, strProducto).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia)).ToList

            Dim NuevaDescripcion As String = String.Empty
            Dim delimitadores() As String = {" "}
            Dim vectoraux() As String
            vectoraux = strProducto.Split(delimitadores, StringSplitOptions.None)

            'mostrar resultado
            For Each item As String In vectoraux
                NuevaDescripcion += item & "%"
            Next


            objAlmacen.descripcion = NuevaDescripcion ' String.Concat("%", NuevaDescripcion)
            objAlmacen.tipoExistencia = strTipoExistencia
            objAlmacen.idEmpresa = Gempresas.IdEmpresaRuc

            'For Each i As usp_GetProductsWithSinInventario_Result In CanastaSA.GetProductsShopingOrOthersSinInv(objAlmacen)
            For Each i In products
                cprecioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
                cprecioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
                cprecioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.origenProducto
                dr(1) = i.codigodetalle
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
                dr(18) = 0
                dr(19) = "-"
                dr(20) = "-"
                dt.Rows.Add(dr)
            Next
            'For Each i As totalesAlmacen In CanastaSA.GetInventarioParaVentaAcumuladoEspecial(New totalesAlmacen _
            '                                                                          With {
            '                                                   .tipoExistencia = strTipoExistencia,
            '                                                   .descripcion = strProducto,
            '                                                   .NomAlmacen = ""})
            '    If i.cantidad > 0 Then
            '        Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / (i.cantidad)
            '        Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / (i.cantidad)

            '        cprecioVentaFinalMenorMN = i.precioVentaFinalMenorMN
            '        cprecioVentaFinalMayorMN = i.precioVentaFinalMayorMN
            '        cprecioVentaFinalGMayorMN = i.precioVentaFinalGMayorMN

            '        Dim dr As DataRow = dt.NewRow()
            '        dr(0) = i.origenRecaudo
            '        dr(1) = i.idItem
            '        dr(2) = i.descripcion
            '        dr(3) = i.unidadMedida
            '        dr(4) = i.Presentacion
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
            '    End If
            'Next
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
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub GetproductoUnicoV2(idPrecio As Integer, nombre As String, valorPrecio As Decimal)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim sa As New TotalesAlmacenSA
        Dim listaInventario As List(Of totalesAlmacen)
        Dim r As Record
        r = GridTotales.Table.CurrentRecord
        'Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))
        If validaSelPrecioVenta = True Then
            If valorPrecio <= 0 Then
                MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        listaInventario = New List(Of totalesAlmacen)
        'Select Case monedaVenta
        '    Case "SOL"
        Dim conf As New configuracionPrecioProducto With
                    {
                    .idPrecio = idPrecio,
                    .descripcion = nombre,
                    .precioMN = valorPrecio,
                    .precioME = 0
                }

                listaInventario = GetInventarioUnicoV2(r, conf)
        'Case "USD"
        '    Dim conf As New configuracionPrecioProducto With
        '        {
        '        .idPrecio = idPrecio,
        '        .descripcion = nombre,
        '        .precioMN = 0,
        '        .precioME = valorPrecio
        '    }

        'listaInventario = GetInventarioUnicoV2(r, conf)
        'End Select

        If listaInventario.Count > 0 Then
            Dim miInterfaz As IListaInventario = TryCast(Me.Owner, IListaInventario)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarListaArticulos(listaInventario)
            Hide()
        End If
    End Sub

    Private Function GetInventarioUnicoV2(Record As Record, precio As configuracionPrecioProducto) As List(Of totalesAlmacen)
        Dim lista2 As New List(Of totalesAlmacen)
        Dim detalleItemsSA As New detalleitemsSA
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
            Dim t = detalleitemsSA.InvocarProductoID(Record.GetValue("idItem"))

            cantidadDisponibleXLote = 0
            If CantidadSolicitadaUM > 0 Then

                obj = New totalesAlmacen
                obj.idEmpresa = t.idEmpresa
                obj.idEstablecimiento = t.idEstablecimiento
                obj.idItem = t.codigodetalle
                obj.descripcion = t.descripcionItem
                obj.origenRecaudo = t.origenProducto
                obj.cantidad = CantidadSolicitadaUM
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

                    GetInventarioUnicoV2.Add(obj)
                    'GetMappingInventarioVerificadoSinControl = obj
                Else
                    Throw New Exception("Ingrese una cantidad válida")
                End If

            End If
        End If

    End Function

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub


    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Dim tipoMercaderia As String = "01"
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)
                If RbMercaderia.Checked Then
                    tipoMercaderia = TipoExistencia.Mercaderia
                ElseIf RBProductosTerminados.Checked Then
                    tipoMercaderia = TipoExistencia.ProductoTerminado
                End If
                'If CheckBoxTC.Checked = False Then
                ObtenerCanastaVentaFiltro(tipoMercaderia, txtFiltrar.Text.Trim)
                'ElseIf CheckBoxTC.Checked = True Then
                '    If txtTipoCambio.Text.Trim.Length > 0 Then
                '        If IsNumeric(txtTipoCambio.Text) Then
                '            If Val(txtTipoCambio.Text) > 0 Then
                '                ObtenerCanastaVentaFiltroDolares(tipoMercaderia, txtFiltrar.Text.Trim)
                '            Else
                '                txtTipoCambio.Select()
                '            End If
                '        Else
                '            txtTipoCambio.Select()
                '        End If
                '    Else
                '        txtTipoCambio.Select()
                '    End If
                'End If

                '  lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
            Else
                '   lblEstado.Text = "Digitar un producto válido!"
            End If

        End If
        Me.Cursor = Cursors.Arrow
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

    Private Function GetInventarioUnico(Record As Record, precio As configuracionPrecioProducto) As List(Of totalesAlmacen)
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


            'Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
            '                                    {.idEmpresa = Gempresas.IdEmpresaRuc,
            '                                    .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
            '                                    .idItem = Integer.Parse(Record.GetValue("idItem"))
            '                                    })

            'Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

            'If cantidadDisponible <= 0 Then
            '    Throw New Exception("Stock cero")
            'End If

            'If CantidadSolicitada > cantidadDisponible Then
            '    '    cantidadComprada = CantidadSolicitada - cantidadDisponible
            '    Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
            '    '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
            'End If

            GetInventarioUnico = New List(Of totalesAlmacen)

            'If lista.Count > 0 Then
            obj = New totalesAlmacen
            obj.idEmpresa = Gempresas.IdEmpresaRuc
            'obj = lista.FirstOrDefault
            obj.cantidad = CantidadSolicitada
            obj.idItem = Record.GetValue("idItem")
            obj.descripcion = Record.GetValue("descripcion")
            obj.unidadMedida = Record.GetValue("unidad")
            obj.importeSoles = CantidadSolicitada * precio.precioMN ' cantidadDisponibleXLote
            obj.tipoExistencia = TipoExistencia.Mercaderia
            obj.origenRecaudo = Record.GetValue("destino")
            obj.tipoConfiguracion = precio.idPrecio
            obj.PMprecioMN = precio.precioMN
            obj.PMprecioME = precio.precioME
            obj.tipoConfiguracion = precio.idPrecio
            GetInventarioUnico.Add(obj)
            'End If



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

        Dim CantidadSolicitada = InputBox("Ingrese cantidad de venta" & vbCrLf &
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

                GetMappingInventarioVerificadoSinControl = obj
            Else
                Throw New Exception("Ingrese una cantidad válida")
            End If


        End If
    End Function

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
            ElseIf e.Inner.ColIndex = 5 Then
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

            ElseIf e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
            End If
        End If
    End Sub
    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTotales.TableControlPushButtonClick
        'Me.Cursor = Cursors.WaitCursor
        'Try
        '    If e.Inner.ColIndex = 4 Then
        '        Dim precioMenor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 4).CellValue)
        '        'If validaStocks = True Then
        '        '    '          GetproductoSelect(1, "Precio por Menor", precioMenor)
        '        'GetproductoUnico(1, "Precio por Menor", precioMenor)
        '        'Else
        '        GetproductoSelectSinControl(1, "Precio por Menor", precioMenor)
        '        'End If


        '    ElseIf e.Inner.ColIndex = 5 Then
        '        Dim precioMayor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 5).CellValue)
        '        'If validaStocks = True Then
        '        '    'GetproductoSelect(2, "Precio por Mayor", precioMayor)
        '        'GetproductoUnico(2, "Precio por Mayor", precioMayor)
        '        'Else
        '        GetproductoSelectSinControl(2, "Precio por Mayor", precioMayor)
        '        'End If


        '    ElseIf e.Inner.ColIndex = 6 Then
        '        Dim precioGranMayor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue)
        '        'If validaStocks = True Then
        '        '    'GetproductoSelect(3, "Precio por Gran Mayor", precioGranMayor)
        '        'GetproductoUnico(3, "Precio por Gran Mayor", precioGranMayor)
        '        'Else
        '        GetproductoSelectSinControl(3, "Precio por Gran Mayor", precioGranMayor)
        '        'End If

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Atención")
        'End Try

        'Me.Cursor = Cursors.Arrow
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 4 Then
                'Dim precioMenor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 4).CellValue)
                ''If validaStocks = True Then
                ''    '          GetproductoSelect(1, "Precio por Menor", precioMenor)
                ''GetproductoUnico(1, "Precio por Menor", precioMenor)
                ''Else
                'GetproductoSelectSinControl(1, "Precio por Menor", precioMenor)
                ''End If

                Dim precioMenor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 4).CellValue)
                'If validaStocks = True Then
                '          GetproductoSelect(1, "Precio por Menor", precioMenor)
                'GetproductoUnico(1, "Precio por Menor", precioMenor)

                GetproductoUnicoV2(1, "Precio por Menor", precioMenor)
                'Else
                '    GetproductoSelectSinControl(1, "Precio por Menor", precioMenor)
                'End If

            ElseIf e.Inner.ColIndex = 5 Then
                'Dim precioMayor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 5).CellValue)
                ''If validaStocks = True Then
                ''    'GetproductoSelect(2, "Precio por Mayor", precioMayor)
                ''GetproductoUnico(2, "Precio por Mayor", precioMayor)
                ''Else
                'GetproductoSelectSinControl(2, "Precio por Mayor", precioMayor)
                ''End If
                Dim precioMayorMN = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 5).CellValue)

                GetproductoUnicoV2(2, "Precio por Mayor", precioMayorMN)

            ElseIf e.Inner.ColIndex = 6 Then
                'Dim precioGranMayor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue)
                ''If validaStocks = True Then
                ''    'GetproductoSelect(3, "Precio por Gran Mayor", precioGranMayor)
                ''GetproductoUnico(3, "Precio por Gran Mayor", precioGranMayor)
                ''Else
                'GetproductoSelectSinControl(3, "Precio por Gran Mayor", precioGranMayor)
                ''End If
                Dim precioGranMayor = Decimal.Parse(GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue)

                GetproductoUnicoV2(3, "Precio por Gran Mayor", precioGranMayor)
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridTotales.Table.CurrentRecord
        Try
            If r IsNot Nothing Then
                Dim nombreProducto As String = r.GetValue("descripcion")
                txtFiltrar.Text = nombreProducto
                Dim CantidadSolicitada = InputBox("Ingrese cantidad a comprar" & vbCrLf &
                                               r.GetValue("descripcion"), "")
                If IsNumeric(CantidadSolicitada) Then
                    If CantidadSolicitada > 0 Then
                        Grabar(CantidadSolicitada)
                        ObtenerCanastaVentaFiltro("01", txtFiltrar.Text.Trim)
                    Else
                        MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe ingresar un número valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            'e.SuppressKeyPress = True
            'If TextCodigoBarra.Text.Trim.Length > 0 Then
            '    ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)
            '    If RbMercaderia.Checked Then
            '        tipoMercaderia = TipoExistencia.Mercaderia
            '    ElseIf RBProductosTerminados.Checked Then
            '        tipoMercaderia = TipoExistencia.ProductoTerminado
            '    End If
            '    ObtenerCanastaVentaFiltroCodigo(tipoMercaderia, TextCodigoBarra.Text.Trim)
            '    '  lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
            'Else
            '    '   lblEstado.Text = "Digitar un producto válido!"
            'End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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

    Private Sub GridTotales_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlCurrentCellKeyDown
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
End Class