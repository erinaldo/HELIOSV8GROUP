Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class UCEstructuraCabeceraVentaTouch

#Region "Attributes"
    Dim popup As Popup
    '  Private UCCanastaDeVentas As UCCanstaDeVentas
    Public Property usercontrol As UserControlCanastaTouch
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Private Property ProductoSA As New detalleitemsSA
    Public Property FormPurchase As FormVentaNuevaTouch
    Public Property ListaDocumentos As List(Of tabladetalle)
    Public listaProductos As List(Of detalleitems)
    Private Property UCPreciosCanastaVenta As UCPreciosCanastaVenta
    '   Public listaEquivalencias As List(Of detalleitem_equivalencias)

    Public Event OKEvent()
    Public Property ManipulacionEstado As String
    Public Property ObjDatosComplementarios As ocupacionInfraestructura
    Public Property ListaPersonasHospedadas As New List(Of personaBeneficio)
    Private Property UCHospedados As UCHospedados
    Public Property txtIDResponsable As Integer
    Public Property txtNombreResponsable As String

#End Region

#Region "Constructors"
    Public Sub New(formventaNueva As FormVentaNuevaTouch)

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
        usercontrol = New UserControlCanastaTouch(Me)
        popup = New Popup(usercontrol)
        popup.Resizable = True
        UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}
        UCPreciosCanastaVenta.BringToFront()
        UCPreciosCanastaVenta.Visible = False
        PanelBody.Controls.Add(UCPreciosCanastaVenta)

        UCHospedados = New UCHospedados With {.Dock = DockStyle.Fill}
        UCHospedados.BringToFront()
        UCHospedados.Visible = False
        PanelBody.Controls.Add(UCHospedados)

        AddHandler usercontrol.OKEvent, AddressOf ucB_OKEvent
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        txtCheckIn.Value = DateTime.Now
        txtCheckOn.Value = DateAdd(DateInterval.Day, 1, txtCheckIn.Value)
        txtdias.Text = 1


    End Sub
#End Region

#Region "Methods"
    Public Sub ucB_OKEvent()
        popup.Hide()
        'Debug.Print("OK Event received from UserControl in FormB")
        RaiseEvent OKEvent()
    End Sub

    Sub BuscarProducto()
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
            listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text
                                                          })

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
        usercontrol.GridTotales.DataSource = dt
        usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
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
        usercontrol.GridTotales.DataSource = dt
        usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
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
        dt.Columns.Add("fraccion")

        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(1).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.fraccionUnidad)
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

    Private Sub ActualizarDatos(dias As Integer)
        Try
            Dim obj As documentoventaAbarrotesDet


            Dim CONSULTA = (From a In ListaproductosVendidos Where a.tipoExistencia = "IF").FirstOrDefault

            If (Not IsNothing(CONSULTA)) Then

                'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
                'Decimal.Parse(r.GetValue("totalmn"))
                Dim precioVentaValue As Decimal = CONSULTA.PrecioUnitarioVentaMN.GetValueOrDefault
                Dim canti As Decimal = dias
                Dim baseImponible As Decimal = 0
                Dim Iva As Decimal = 0
                Dim total As Decimal = canti * CONSULTA.PrecioUnitarioVentaMN.GetValueOrDefault
                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Iva = Math.Round(total - baseImponible, 2)


                obj = New documentoventaAbarrotesDet
                obj.CodigoCosto = 1
                obj.CustomProducto = New detalleitems
                obj.CustomProducto.origenProducto = 1
                obj.CustomProducto.descripcionItem = CONSULTA.CustomProducto.descripcionItem
                obj.CustomProducto.unidad1 = "NIU"
                obj.CustomProducto.codigodetalle = CONSULTA.CustomProducto.codigodetalle
                obj.CustomProducto.tipoExistencia = "IF"
                obj.CustomEquivalencia = New detalleitem_equivalencias
                obj.CustomEquivalencia.fraccionUnidad = 0
                obj.idItem = CONSULTA.idItem
                obj.DetalleItem = CONSULTA.DetalleItem
                obj.catalogo_id = 0
                obj.monto1 = CDec(txtdias.Text)
                obj.unidad1 = "NIU"
                obj.tipoExistencia = "IF"
                obj.montokardex = CDec(baseImponible)
                obj.montoIgv = Iva
                obj.importeMN = total
                obj.PrecioUnitarioVentaMN = precioVentaValue
                obj.precioUnitario = precioVentaValue
                obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                obj.CustomEquivalencia.equivalencia_id = 0
                obj.CustomCatalogo = New detalleitemequivalencia_catalogos
                obj.CustomCatalogo.idCatalogo = 0
                obj.FlagBonif = False
                obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                'obj.CustomDocumentoCaja = New List(Of documentoCaja)

                ListaproductosVendidos.Remove(CONSULTA)
                ListaproductosVendidos.Add(obj)
                LoadCanastaVentas(ListaproductosVendidos)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub GetTotalesDocumento()
        Dim sumaTotal As Decimal = 0
        Dim sumaBaseImponible1 As Decimal = 0
        Dim sumaBaseImponible2 As Decimal = 0
        Dim sumaIva1 As Decimal = 0
        Dim sumaIva2 As Decimal = 0
        Dim descuento As Decimal = TextDescuento.DecimalValue
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
        TextSubTotal.DecimalValue = sumaTotal
        txtTotalPagar.DecimalValue = sumaTotal - descuento
        txtTotalBase.DecimalValue = sumaBaseImponible1
        txtTotalBase2.DecimalValue = sumaBaseImponible2
        txtTotalIva.DecimalValue = sumaIva1
    End Sub

    Private Sub GetTablasGenerales()
        Dim listaMoneda = General.TablasGenerales.GetMonedas()
        ListaDocumentos = GetComprobantesCompra()
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9903", .descripcion = "PROFORMA"})
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "1000", .descripcion = "PEDIDO"})

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
                                        GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
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
                        Case "CODIGO BARRA"
                            BuscarProductoBarCode()
                            If listaProductos.Count > 0 AndAlso listaProductos.Count = 1 Then
                                Dim equivalencia = usercontrol.GridTotales.Table.Records(0).GetValue("cboEquivalencias")
                                Dim CatalogoPrecio = usercontrol.GridTotales.Table.Records(0).GetValue("cboPrecios")
                                ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                                Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = usercontrol.GridTotales.Table.Records(0).GetValue("idItem")).SingleOrDefault

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
                                        usercontrol.GridTotales.Table.Records(0).SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                    Else
                                        usercontrol.GridTotales.Table.Records(0).SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                    End If

                                    usercontrol.GridTotales.Table.Records(0).SetCurrent("descripcion")
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

                                Dim idProducto = Me.usercontrol.GridTotales.Table.Records(0).GetValue("idItem")
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

                                Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                                Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                                Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                            ElseIf listaProductos.Count <= 0 Then
                                PictureLoadingProduct.Visible = False
                                MessageBox.Show("El código ingresado no se encuentra en la base de datos de productos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextFiltrar.Clear()
                                TextFiltrar.Select()
                            End If

                        Case "PRODUCTO"
                            BuscarProducto()

                            If listaProductos.Count > 0 Then
                                popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                                PictureLoadingProduct.Visible = False

                                'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
                                'rec.SetCurrent("descripcion")
                                'usercontrol.GridTotales.Focus()

                                Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                                Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                                Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
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
                popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
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

    Public Sub AgregarProductoDetalleVenta(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal, eq As detalleitem_equivalencias, CatalogoPrecio As Integer)
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
            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()
            obj.AfectoInventario = True
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
            'obj.CustomDocumentoCaja = New List(Of documentoCaja)
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
        obj.estadoEntrega = "SI"
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
                    GetCalculoItem(rec)
                    EditarItemVenta(rec)
                    Throw New Exception("El producto no tiene precios de venta asignados")
                End If

                For Each i In listaDeRangos
                    Dim rango_inicio = i.rango_inicio
                    Dim rango_fin = i.rango_final
                    If cantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then

                        If FormPurchase.ComboComprobante.Text = "PEDIDO" Then
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
                        If FormPurchase.ComboComprobante.Text = "PEDIDO" Then
                            GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                        Else
                            Select Case ComboTerminosPago.Text
                                Case "CONTADO"
                                    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                Case "CREDITO"
                                    GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
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
                Next
            Else
                rec.SetValue("precioventa", 0)
                GetCalculoItem(rec)
                EditarItemVenta(rec)
                Throw New Exception("Debe configurar los catálogos de precios!")
            End If
        End If
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

                        If FormPurchase.ComboComprobante.Text = "PEDIDO" Then
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
                        If FormPurchase.ComboComprobante.Text = "PEDIDO" Then
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
    Private Function AddItemNuevaListaPrecios(be As detalleitemequivalencia_precios, rangoMinimo As Integer?, max As Integer) As detalleitemequivalencia_precios

        AddItemNuevaListaPrecios = New detalleitemequivalencia_precios
        AddItemNuevaListaPrecios = be
        AddItemNuevaListaPrecios.rango_inicio = rangoMinimo
        AddItemNuevaListaPrecios.rango_final = max
    End Function

    Private Function ConvertirPreciosArangos(lista As List(Of detalleitemequivalencia_precios)) As List(Of detalleitemequivalencia_precios)
        '   Dim ListaEntera = GetConverToListInteger(lista)

        ConvertirPreciosArangos = New List(Of detalleitemequivalencia_precios)

        Dim maxValor = lista.Max(Function(o) o.rango_inicio).GetValueOrDefault
        Dim max = 0
        For index = 0 To lista.Count - 1
            Dim rangoMinimo = lista(index).rango_inicio
            If rangoMinimo = maxValor Then
                max = 0
            Else
                max = lista(index + 1).rango_inicio.GetValueOrDefault - 1
            End If
            ConvertirPreciosArangos.Add(AddItemNuevaListaPrecios(lista(index), rangoMinimo, max))
        Next
    End Function

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
        dt.Columns.Add("catalogo")
        dt.Columns.Add("descuentoMN")
        dt.Columns.Add("afectoInventario", GetType(Boolean))
        dt.Columns.Add("TipoExistencia")

        For Each i In listaProductos

            Select Case i.tipoExistencia
                Case TipoExistencia.ServicioGasto

                    dt.Rows.Add(i.CodigoCosto,
                  i.CustomProducto.origenProducto,
                  i.CustomProducto.descripcionItem,
                  i.CustomProducto.unidad1,
                  "",
                  i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                  i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                  i.importeMN.GetValueOrDefault, 0,
                  "", If(i.FlagBonif = "True", True, False), "", i.descuentoMN.GetValueOrDefault, i.AfectoInventario,
                    i.tipoExistencia)

                Case Else
                    dt.Rows.Add(i.CodigoCosto,
                    i.CustomProducto.origenProducto,
                    i.CustomProducto.descripcionItem,
                    i.CustomProducto.unidad1,
                    i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
                    i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                    i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                    i.importeMN.GetValueOrDefault, 0,
                    i.CustomEquivalencia.equivalencia_id, If(i.FlagBonif = "True", True, False), i.CustomCatalogo.idCatalogo, i.descuentoMN.GetValueOrDefault, i.AfectoInventario,
                    i.tipoExistencia)
            End Select
        Next
        GridCompra.DataSource = dt
        GridCompra.Refresh()
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Cursor = Cursors.WaitCursor
        BuscarProducto()
        If listaProductos.Count > 0 Then
            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
            PictureLoadingProduct.Visible = False

            'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
            'rec.SetCurrent("descripcion")
            'usercontrol.GridTotales.Focus()

            Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
            Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
            Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
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
                    .montoIgv = Decimal.Parse(r.GetValue("igvmn"))
                    .precioUnitario = 0
                    .importeMN = Decimal.Parse(r.GetValue("totalmn"))
                    .FlagBonif = r.GetValue("bonificacion").ToString
                    .descuentoMN = Decimal.Parse(r.GetValue("descuentoMN"))
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

    Public Sub GetCalculoItemImporte(r As Record)
        If r IsNot Nothing Then
            Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
            Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
            Dim canti As Decimal = CDec(r.GetValue("cantidad"))
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            Dim precioUnitario As Decimal = 0

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

    Public Sub GetCalculoItem(r As Record)
        If r IsNot Nothing Then
            Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
            Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
            Dim canti As Decimal = CDec(r.GetValue("cantidad"))
            Dim descuentoItem As Decimal = CDec(r.GetValue("descuentoMN"))
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            Dim precioUnitario As Decimal = 0

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

    Public Sub GetCalculoItem(rowIndex As Integer)
        If rowIndex <> -1 Then
            Dim bonificacion = If(Boolean.Parse(Me.GridCompra.TableModel(rowIndex, 14).CellValue) = False, True, False)
            Dim recaudo As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 2).CellValue) ' CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 8).CellValue) 'precioventa
            Dim canti As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 7).CellValue)

            Dim descuentoItem As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 16).CellValue)

            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0

            Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))
            total = total - descuentoItem

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
                Me.GridCompra.TableModel(rowIndex, 16).CellValue = descuentoItem

                'r.SetValue("pumn", 0)
                'r.SetValue("totalmn", total)

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

                            If text.Trim.Length > 0 Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then

#Region "Precios"
                                    Dim CodigoEQ As String = r.GetValue("tipofraccion")
                                    Dim value As String = r.GetValue("codigo").ToString()
                                    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                                    Select Case prod.tipoExistencia
                                        Case TipoExistencia.ServicioGasto
                                        Case TipoExistencia.Infraestructura
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

                                    GetCalculoItem(GridCompra.Table.CurrentRecord)
                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If text.Trim.Length > 0 Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
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

                            If text.Trim.Length > 0 Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                    GetCalculoItem(GridCompra.Table.CurrentRecord)
                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "descuentoMN" Then
                    'If cc.Renderer IsNot Nothing Then

                    '    If e.TableControl.Model.Modified = True Then
                    '        Dim text As String = cc.Renderer.ControlText

                    '        Dim r As Record = GridCompra.Table.CurrentRecord

                    '        If text.Trim.Length > 0 Then
                    '            Dim topeMaximo = CDec(r.GetValue("totalmn"))
                    '            Dim montoDescuento As Decimal = CDec(text)

                    '            If montoDescuento <= topeMaximo Then
                    '                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                    '                    GetCalculoItem(GridCompra.Table.CurrentRecord)
                    '                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                    '                End If
                    '            Else
                    '                cc.Renderer.ControlValue = 0
                    '                cc.Renderer.ControlText = 0
                    '                MessageBox.Show("El descuento no debe ser mayor a la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '                Exit Sub
                    '            End If
                    '            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                    '        End If
                    '    End If
                    'End If
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

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick
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
                        Case TipoExistencia.Infraestructura
                        Case Else
                            If idEquiva.Trim.Length > 0 Then
                                Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                Dim idCat = r.GetValue("catalogo").ToString()
                                If idCat.Trim.Length > 0 Then
                                    Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then
                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
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

    Private Sub UCEstructuraCabeceraVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboTipoBusqueda.Items.Add("SERVICIO")
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
                ElseIf style3.TableCellIdentity.Column.Name = "afectoInventario" Then
                    Dim afectaStock = Me.GridCompra.TableModel(RowIndex, 17).CellValue
                    Select Case afectaStock
                        Case "False" 'TRUE
                            If RowIndex <> -1 Then
                                Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = True
                                    End With
                                End If
                            End If
                        Case Else ' FALSE
                            If RowIndex <> -1 Then
                                Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
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
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "tipofraccion" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

            Select Case prod.tipoExistencia
                Case TipoExistencia.ServicioGasto
                Case TipoExistencia.Infraestructura
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


        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "catalogo" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

            Select Case prod.tipoExistencia
                Case TipoExistencia.ServicioGasto
                Case TipoExistencia.Infraestructura
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

        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "importeMn" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cantidad" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then
            Dim strTipoExistencia = Me.GridCompra.TableModel(e.TableCellIdentity.RowIndex, 3).CellValue

            If (strTipoExistencia = txtInfraestructura.Text) Then
                e.Style.[ReadOnly] = True
            Else
                e.Style.[ReadOnly] = False
            End If

        End If

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipofraccion")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        'e.Style.BackColor = Color.Yellow
                        'e.Style.TextColor = Color.Black
                        e.Style.Enabled = False
                    Case TipoExistencia.Infraestructura
                        e.Style.Enabled = False
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "catalogo")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                        e.Style.Enabled = False
                    Case TipoExistencia.Infraestructura
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                        e.Style.Enabled = False
                    Case Else
                        e.Style.Enabled = True
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        e.Style.BackColor = Color.FromKnownColor(KnownColor.InactiveBorder)
                        e.Style.TextColor = Color.Black
                        e.Style.Enabled = False
                        e.Style.Text = 1
                    Case TipoExistencia.Infraestructura
                        e.Style.BackColor = Color.FromKnownColor(KnownColor.InactiveBorder)
                        e.Style.TextColor = Color.Black
                        e.Style.Enabled = False

                    Case Else
                        e.Style.Enabled = True
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "igvmn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "pumn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "descuentoMN")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "bonificacion")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
                        e.Style.Enabled = False
                        e.Style.Text = False
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "afectoInventario")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
                        e.Style.Enabled = False
                        e.Style.Text = True
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "precioventa")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN"
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

                        Select Case prod.tipoExistencia
                            Case TipoExistencia.ServicioGasto
                            Case TipoExistencia.Infraestructura
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

                        GetCalculoItem(r)
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

                        Select Case prod.tipoExistencia
                            Case TipoExistencia.ServicioGasto
                            Case TipoExistencia.Infraestructura
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
                                GetCalculoItem(r)
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

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click
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
                        UCHospedados.Visible = False
                    Case "INFO. COMPRA"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCPreciosCanastaVenta.Visible = False
                        UCHospedados.Visible = False
                    Case "PRECIOS"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCPreciosCanastaVenta.Visible = True
                        UCHospedados.Visible = False
                    Case "BENEFICIOS"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCPreciosCanastaVenta.Visible = False
                        UCHospedados.Visible = False
                    Case "HOSPEDADOS"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCPreciosCanastaVenta.Visible = False
                        UCHospedados.GetDetallePersonaBeneficio(ListaPersonasHospedadas)
                        UCHospedados.Visible = True
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

                                Select Case prod.tipoExistencia
                                    Case TipoExistencia.ServicioGasto
                                    Case TipoExistencia.Infraestructura
                                    Case Else
                                        Dim idEquiva = currenrecord.GetValue("tipofraccion").ToString()

                                        If idEquiva.Trim.Length > 0 Then
                                            Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                            Dim idCat = currenrecord.GetValue("catalogo").ToString()
                                            If idCat.Trim.Length > 0 Then
                                                Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                                UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                                If OBJCatalog IsNot Nothing Then

                                                    Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)

                                                    UCPreciosCanastaVenta.GetDetallePrecios(lista)
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
                                ' Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                                '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                                If currenrecord IsNot Nothing Then
                                    Dim value As String = currenrecord.GetValue("codigo").ToString()
                                    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                                    Select Case prod.tipoExistencia
                                        Case TipoExistencia.ServicioGasto
                                        Case TipoExistencia.Infraestructura
                                        Case Else
                                            Dim idEquiva = currenrecord.GetValue("tipofraccion").ToString()

                                            If idEquiva.Trim.Length > 0 Then
                                                Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                                Dim idCat = currenrecord.GetValue("catalogo").ToString()
                                                If idCat.Trim.Length > 0 Then
                                                    Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                                    If OBJCatalog IsNot Nothing Then
                                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                                    End If

                                                Else
                                                End If
                                            End If
                                    End Select
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
                            '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))

                            If currenrecord IsNot Nothing Then
                                Dim value As String = currenrecord.GetValue("codigo").ToString()
                                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                                Select Case prod.tipoExistencia
                                    Case TipoExistencia.ServicioGasto
                                    Case TipoExistencia.Infraestructura
                                    Case Else
                                        Dim idEquiva = currenrecord.GetValue("tipofraccion").ToString()

                                        If idEquiva.Trim.Length > 0 Then
                                            Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                            Dim idCat = currenrecord.GetValue("catalogo").ToString()
                                            If idCat.Trim.Length > 0 Then
                                                Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                                UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                                If OBJCatalog IsNot Nothing Then
                                                    Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                                    UCPreciosCanastaVenta.GetDetallePrecios(lista)
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
                    SelRazon.tipoEntidad = "PR"
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
                    SelRazon.tipoEntidad = "PR"
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

            Case "SERVICIO"
                ButtonAddServicio.Visible = True
                TextFiltrar.Clear()
                TextFiltrar.Select()

            Case "CODIGO BARRA"
                ButtonAddServicio.Visible = False
                TextFiltrar.Clear()
                TextFiltrar.Select()

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

                If style.TableCellIdentity.Column.Name = "descuentoMN" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If text.Trim.Length > 0 Then
                                Dim topeMaximo = CDec(r.GetValue("cantidad")) * CDec(r.GetValue("precioventa"))
                                Dim montoDescuento As Decimal = CDec(r.GetValue("descuentoMN"))

                                If montoDescuento <= topeMaximo Then
                                    If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                        GetCalculoItem(GridCompra.Table.CurrentRecord)
                                        EditarItemVenta(GridCompra.Table.CurrentRecord)
                                    End If
                                Else
                                    cc.Renderer.ControlValue = 0
                                    cc.Renderer.ControlText = 0
                                    r.SetValue("descuentoMN", 0)
                                    MessageBox.Show("El descuento no debe ser mayor a la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    GetCalculoItem(r)
                                    EditarItemVenta(r)
                                    Exit Sub
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub TxtCheckIn_ValueChanged(sender As Object, e As EventArgs) Handles txtCheckIn.ValueChanged
        Try
            'If txtCheckIn.Value.Date < txtCheckOn.Value.Date Then
            Dim DiferenciaDias As Integer = DateDiff(DateInterval.Day, txtCheckIn.Value, txtCheckOn.Value) + 1
                txtdias.Text = DiferenciaDias
                ActualizarDatos(txtdias.Text)
                GetTotalesDocumento()
            'Else
            '    txtCheckIn.Value = DateTime.Now
            '    txtCheckOn.Value = DateAdd(DateInterval.Day, 1, txtCheckIn.Value)
            '    txtdias.Text = 1
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TxtCheckOn_ValueChanged(sender As Object, e As EventArgs) Handles txtCheckOn.ValueChanged
        Try
            If (txtCheckOn.Tag = 0) Then
                'If txtCheckOn.Value.Date > txtCheckIn.Value.Date Then
                Dim DiferenciaDias As Integer = DateDiff(DateInterval.Day, txtCheckIn.Value, txtCheckOn.Value) + 1
                    txtdias.Text = DiferenciaDias
                    ActualizarDatos(txtdias.Text)
                    GetTotalesDocumento()
                'Else
                '    txtCheckIn.Value = DateTime.Now
                '    txtCheckOn.Value = DateAdd(DateInterval.Day, 1, txtCheckIn.Value)
                '    txtdias.Text = 1
                'End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txtdias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdias.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                txtCheckOn.Tag = 1
                txtCheckOn.Value = DateAdd(DateInterval.Day, CInt(txtdias.Text), txtCheckIn.Value)
                txtCheckOn.Tag = 0
                ActualizarDatos(txtdias.Text)
                GetTotalesDocumento()

                ObjDatosComplementarios = New ocupacionInfraestructura
                ObjDatosComplementarios.idEmpresa = Gempresas.IdEmpresaRuc
                ObjDatosComplementarios.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                ObjDatosComplementarios.[idDistribucion] = txtInfraestructura.Tag
                ObjDatosComplementarios.[idEntidad] = TextProveedor.Tag
                ObjDatosComplementarios.[chek_in] = txtCheckIn.Value
                ObjDatosComplementarios.[check_on] = txtCheckOn.Value
                ObjDatosComplementarios.[estado] = "A"
                ObjDatosComplementarios.[glosario] = "Datos complementarios"
                ObjDatosComplementarios.[usuarioActualizacion] = usuario.IDUsuario
                ObjDatosComplementarios.[fechaActualizacion] = DateTime.Now

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            Dim f As New frmListaPersonasHospedados(ListaPersonasHospedadas)
            If (TextNumIdentrazon.Text.Length = 8) Then
                If (TextNumIdentrazon.Text <> "1") Then
                    f.TextProveedor.Text = TextProveedor.Text
                    f.TextNumIdentrazon.Text = TextNumIdentrazon.Text
                End If
            End If

                f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, List(Of personaBeneficio))
                ListaPersonasHospedadas = c
                RoundButton21.Text = "HOSPEDADOS(" & ListaPersonasHospedadas.Count & ")"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CheckStock_OnChange(sender As Object, e As EventArgs) Handles CheckStock.OnChange

    End Sub

    Private Sub Txtdias_TextChanged(sender As Object, e As EventArgs) Handles txtdias.TextChanged
        Dim nombres = String.Empty
        Try
            If (txtdias.Tag = 1) Then

                If (txtdias.Text.Length > 0) Then
                    If (txtdias.Text <> "0") Then
                        txtCheckOn.Tag = 1
                        txtCheckOn.Value = DateAdd(DateInterval.Day, CInt(txtdias.Text), txtCheckIn.Value)
                        txtCheckOn.Tag = 0
                        ActualizarDatos(txtdias.Text)
                        GetTotalesDocumento()

                        ObjDatosComplementarios = New ocupacionInfraestructura
                        ObjDatosComplementarios.idEmpresa = Gempresas.IdEmpresaRuc
                        ObjDatosComplementarios.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                        ObjDatosComplementarios.[idDistribucion] = txtInfraestructura.Tag
                        ObjDatosComplementarios.[idEntidad] = TextProveedor.Tag
                        ObjDatosComplementarios.[chek_in] = txtCheckIn.Value
                        ObjDatosComplementarios.[check_on] = txtCheckOn.Value
                        ObjDatosComplementarios.[estado] = "A"
                        ObjDatosComplementarios.[glosario] = "Datos complementarios"
                        ObjDatosComplementarios.[usuarioActualizacion] = usuario.IDUsuario
                        ObjDatosComplementarios.[fechaActualizacion] = DateTime.Now
                    Else
                        txtdias.Text = 1
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txtdias_Click(sender As Object, e As EventArgs) Handles txtdias.Click
        Try
            txtdias.Tag = 1
            txtdias.Select(0, txtdias.Text.Length)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txtdias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdias.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

End Class
