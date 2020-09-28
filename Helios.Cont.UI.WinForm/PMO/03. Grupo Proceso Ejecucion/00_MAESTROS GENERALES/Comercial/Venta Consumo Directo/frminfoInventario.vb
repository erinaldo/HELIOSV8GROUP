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

Public Class frminfoInventario
    Inherits frmMaster

    Public Property idAlmacen As Integer
    Public Sub New(id As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(gridGroupingControl1, True, False)
        'GridCFG(gridGroupingControl1)
        GridCFG(GridGroupingControl2)
        idAlmacen = id
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(gridGroupingControl1, True, False)
        'GridCFG(gridGroupingControl1)
        GridCFG(GridGroupingControl2)
    End Sub

#Region "Métodos"

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

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))
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

    'Public Sub GetPrecioByArticulo(idProducto As Integer)
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    CboPrecios.DataSource = precioSA.ListarPreciosXproductoMaxFecha(0, idProducto)
    '    CboPrecios.DisplayMember = "descripcion"
    '    CboPrecios.ValueMember = "idPrecio"
    'End Sub

    Private Function GetInventarioAcumulado(lista As List(Of totalesAlmacen)) As List(Of totalesAlmacen)
        Dim Inventory = (From art In lista
                         Group art By keys = New With
                           {
                           Key art.origenRecaudo,
                           Key art.idItem,
                           Key art.descripcion,
                           Key art.unidadMedida,
                           Key art.Presentacion,
                           Key art.NomAlmacen,
                           Key art.idAlmacen,
                           Key art.precioVentaFinalMenorMN,
                           Key art.precioVentaFinalMayorMN,
                           Key art.precioVentaFinalGMayorMN
                           }
                       Into Group
                         Select New With
                           {
                           .office = keys.origenRecaudo,
                           .dept = keys.idItem,
                           .descripcion = keys.descripcion,
                           .unidadMedida = keys.unidadMedida,
                           .Presentacion = keys.Presentacion,
                           .NomAlmacen = keys.NomAlmacen,
                           .idAlmacen = keys.idAlmacen,
                           .precioVentaFinalMenorMN = keys.precioVentaFinalMenorMN,
                           .precioVentaFinalMayorMN = keys.precioVentaFinalMayorMN,
                           .precioVentaFinalGMayorMN = keys.precioVentaFinalGMayorMN,
                           .sumStock = Group.Sum(Function(x) x.cantidad)
                           }).ToList

        Return Nothing
    End Function

    Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
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
            dt.Columns.Add("PUiva")

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

            For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproducto(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""}).Where(Function(o) o.idAlmacen = idAlmacen).OrderBy(Function(o) o.descripcion).ToList
                If CDec(i.cantidad) > 0 Then

                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
                    Dim precioCompraConIva As Decimal = 0
                    If i.origenRecaudo = 1 Then
                        precioCompraConIva = valPrecUnitario + (valPrecUnitario * 0.18)
                    Else
                        precioCompraConIva = valPrecUnitario
                    End If

                    'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui

                    cprecioVentaFinalMenorMN = i.precioVentaFinalMenorMN
                    cprecioVentaFinalMayorMN = i.precioVentaFinalMayorMN
                    cprecioVentaFinalGMayorMN = i.precioVentaFinalGMayorMN
                    'If Not IsNothing(lista) Then
                    '    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                    '        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
                    '        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
                    '        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
                    '        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
                    '        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
                    '        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
                    '        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
                    '        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
                    '        'cdetalleMenor = .detalleMenor
                    '        'cdetalleMayor = .detalleMayor
                    '        'cdetalleGMayor = .detalleGMayor
                    '    End With
                    'Else
                    '    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
                    '    lblEstado.Image = My.Resources.warning2
                    'End If

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.origenRecaudo
                    dr(1) = i.idItem
                    dr(2) = i.descripcion
                    dr(3) = i.unidadMedida
                    dr(4) = i.Presentacion
                    dr(5) = i.NomAlmacen
                    dr(6) = i.cantidad
                    dr(7) = valPrecUnitario
                    dr(8) = valPrecUnitarioUS
                    dr(9) = i.importeSoles
                    dr(10) = i.importeDolares

                    dr(11) = cprecioVentaFinalMenorMN
                    dr(12) = cprecioVentaFinalMenorME
                    dr(13) = cprecioVentaFinalMayorMN
                    dr(14) = cprecioVentaFinalMayorME
                    dr(15) = cprecioVentaFinalGMayorMN
                    dr(16) = cprecioVentaFinalGMayorME
                    dr(17) = i.CustomLote.codigoLote
                    dr(18) = i.idAlmacen
                    dr(19) = If(i.CustomLote.productoSustentado = True, "Doc.", "Not.")
                    dr(20) = If(i.CustomLote.fechaVcto.HasValue, i.CustomLote.fechaVcto, "-")
                    dr(21) = precioCompraConIva
                    dt.Rows.Add(dr)
                End If
            Next
            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
            gridGroupingControl1.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            gridGroupingControl1.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

            gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            gridGroupingControl1.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")

            Dim fchooser As FieldChooser = New FieldChooser(gridGroupingControl1)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

    Private Sub frminfoInventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '  Dispose()
    End Sub


    Private Sub frminfoInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                ObtenerCanastaVentaFiltro(0, tipoMercaderia, txtFiltrar.Text.Trim)
                '  lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
            Else
                '   lblEstado.Text = "Digitar un producto válido!"
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub gridGroupingControl1_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles gridGroupingControl1.SelectedRecordsChanged
        'Me.Cursor = Cursors.WaitCursor
        'GridGroupingControl2.Table.Records.DeleteAll()
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick
        'Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
        '    UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl2.TableControlCellClick

    End Sub

    Private Sub GridGroupingControl2_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles GridGroupingControl2.TableControlCurrentCellControlDoubleClick
        '   GetproductoSelect()
    End Sub

    Private Sub GetproductoSelect()
        Dim precioSA As New ConfiguracionPrecioProductoSA
        '   Dim obj As New totalesAlmacen
        Dim sa As New TotalesAlmacenSA
        Dim r As Record

        '     obj = New totalesAlmacen
        r = gridGroupingControl1.Table.CurrentRecord
        Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))

        If precios.Count = 0 Then
            MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If

        Dim obj = sa.GetUbicarArticuloLote(New totalesAlmacen With {.idAlmacen = Integer.Parse(r.GetValue("idalmacen")), .idItem = Val(r.GetValue("idItem")), .codigoLote = Integer.Parse(r.GetValue("codigoLote"))})
        obj.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
        obj.idAlmacen = Integer.Parse(r.GetValue("idalmacen"))
        obj.NomAlmacen = r.GetValue("presentacion")

        obj.PMprecioMN = precios.FirstOrDefault.precioMN ' Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
        obj.PMprecioME = precios.FirstOrDefault.precioME 'Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciome")
        obj.tipoConfiguracion = precios.FirstOrDefault.idPrecio 'Me.GridGroupingControl2.Table.CurrentRecord.GetValue("idPrecio")
        obj.Marca = r.GetValue("tipo")
        obj.SelecionDirecta = ChSelecDirecta.Checked
        'If obj.ArticulosConexos IsNot Nothing Then
        '    MsgBox("Tiene enlaces: " & obj.Count)
        'End If

        If Not IsNothing(obj) Then
            'Tag = obj.First
            'Close()

            Dim miInterfaz As IForm = TryCast(Me.Owner, IForm)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarProducto(obj)

        End If

    End Sub

    Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellDoubleClick
        If gridGroupingControl1.Table.SelectedRecords.Count > 0 Then
            GetproductoSelect()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            gridGroupingControl1.TableDescriptor.Columns("puKardexmn").Width = 70
            gridGroupingControl1.TableDescriptor.Columns("PUiva").Width = 70
        Else
            gridGroupingControl1.TableDescriptor.Columns("puKardexmn").Width = 0
            gridGroupingControl1.TableDescriptor.Columns("PUiva").Width = 0
        End If
    End Sub
End Class