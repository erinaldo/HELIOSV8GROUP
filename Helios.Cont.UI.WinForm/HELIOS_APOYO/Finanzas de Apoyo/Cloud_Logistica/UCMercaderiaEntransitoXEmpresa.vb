Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Runtime.Serialization
Imports Syncfusion.Windows.Forms

Public Class UCMercaderiaEntransitoXEmpresa

#Region "Attributes"
    Private Property compraSA As New DocumentoCompraDetalleSA
    Private Property almacenSA As New almacenSA
    Public Property ListaAlmacen As List(Of almacen)
    Private listaProductos As List(Of inventarioTransito)
    Private UCEntrega As UCEntregaDeMercaderiaLogistica
    Private Property UCLogisticaAlmacen As UCLogisticaAlmacen
#End Region

#Region "Contructors"
    Public Sub New(UCEntregaDeMercaderiaLogistica As UCEntregaDeMercaderiaLogistica)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCEntrega = UCEntregaDeMercaderiaLogistica
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        listaProductos = New List(Of inventarioTransito)
        ListaAlmacen = New List(Of almacen)
        GetLoadAlmacenes()
        GetProductosEntransito()
        LoadProductosTransito()
        'GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Public Sub New(form As UCLogisticaAlmacen)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCLogisticaAlmacen = form
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        listaProductos = New List(Of inventarioTransito)
        ListaAlmacen = New List(Of almacen)
        'GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        'GetLoadAlmacenes()
        'GetProductosEntransito()
        'LoadProductosTransito()
    End Sub


#End Region

#Region "Class LinkLabel"
    Public Class LinkLabelCellModel
        Inherits GridStaticCellModel

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal grid As GridModel)
            MyBase.New(grid)
        End Sub

        Public Overrides Function CreateRenderer(ByVal control As GridControlBase) As GridCellRendererBase
            Return New LinkLabelCellRenderer(control, Me)
        End Function
    End Class

    Public Class LinkLabelCellRenderer
        Inherits GridStaticCellRenderer

        Private _isMouseDown As Boolean
        Private _drawHotLink As Boolean
        Private _hotColor As Color
        Private _visitedColor As Color
        Private _EXEname As String

        Public Sub New(ByVal grid As GridControlBase, ByVal cellModel As GridCellModelBase)
            MyBase.New(grid, cellModel)
            _isMouseDown = False
            _drawHotLink = False
            _hotColor = Color.Red
            _visitedColor = Color.Purple
            _EXEname = "iexplore.exe"
        End Sub

        Public Property VisitedLinkColor As Color
            Get
                Return _visitedColor
            End Get
            Set(ByVal value As Color)
                _visitedColor = value
            End Set
        End Property

        Public Property ActiveLinkColor As Color
            Get
                Return _hotColor
            End Get
            Set(ByVal value As Color)
                _hotColor = value
            End Set
        End Property

        Public Property EXEname As String
            Get
                Return _EXEname
            End Get
            Set(ByVal value As String)
                _EXEname = value
            End Set
        End Property

        Private Sub DrawLink(ByVal useHotColor As Boolean, ByVal rowIndex As Integer, ByVal colIndex As Integer)
            If useHotColor Then _drawHotLink = True
            Me.Grid.RefreshRange(GridRangeInfo.Cell(rowIndex, colIndex), GridRangeOptions.None)
            _drawHotLink = False
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(rowIndex, colIndex, e)
            DrawLink(True, rowIndex, colIndex)
            _isMouseDown = True
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(rowIndex, colIndex, e)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(New Point(e.X, e.Y), row, col)

            If row = rowIndex AndAlso col = colIndex Then
                Dim style As GridStyleInfo = Me.Grid.Model(row, col)
                style.TextColor = VisitedLinkColor
            End If

            DrawLink(False, rowIndex, colIndex)
            _isMouseDown = False
        End Sub

        Protected Overrides Sub OnCancelMode(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnCancelMode(rowIndex, colIndex)
            _isMouseDown = False
            _drawHotLink = False
        End Sub

        Protected Overrides Function OnGetCursor(ByVal rowIndex As Integer, ByVal colIndex As Integer) As System.Windows.Forms.Cursor
            Dim pt As Point = Me.Grid.PointToClient(Cursor.Position)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(pt, row, col)
            Return If((row = rowIndex AndAlso col = colIndex), Cursors.Hand, If((Me._isMouseDown), Cursors.No, MyBase.OnGetCursor(rowIndex, colIndex)))
        End Function

        Protected Overrides Function OnHitTest(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As MouseEventArgs, ByVal controller As IMouseController) As Integer
            If controller IsNot Nothing AndAlso controller.Name = "OleDataSource" Then Return 0
            Return 1
        End Function

        Protected Overrides Sub OnDraw(ByVal g As System.Drawing.Graphics, ByVal clientRectangle As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal style As Syncfusion.Windows.Forms.Grid.GridStyleInfo)
            style.Font.Underline = True

            If _drawHotLink Then
                style.TextColor = ActiveLinkColor
            End If

            MyBase.OnDraw(g, clientRectangle, rowIndex, colIndex, style)
        End Sub

        Protected Overrides Sub OnMouseHoverEnter(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnMouseHoverEnter(rowIndex, colIndex)
            DrawLink(True, rowIndex, colIndex)
        End Sub

        Protected Overrides Sub OnMouseHoverLeave(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.EventArgs)
            MyBase.OnMouseHoverLeave(rowIndex, colIndex, e)
            DrawLink(False, rowIndex, colIndex)
        End Sub
    End Class
#End Region

#Region "Methods"
    Private Sub Expression()

        With Me.GridCompra.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.ValidateValue

        End With

        Dim expField1 As New ExpressionFieldDescriptor("Winning %", "IF([wins]<100,[losses],0)", GetType(System.Double))
        Dim expField2 As New ExpressionFieldDescriptor("Losing %", "IF([losses]<100,[wins],0)", GetType(System.Double))
        Me.GridCompra.TableDescriptor.ExpressionFields.AddRange(New ExpressionFieldDescriptor() {expField1, expField2})
    End Sub

    Public Sub GetLoadAlmacenes()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add("2", "EN CURSO")
        dt.Rows.Add("3", "ENTREGADO")

        Dim ggcStyleStatus As GridTableCellStyleInfo = GridCompra.TableDescriptor.Columns("status").Appearance.AnyRecordFieldCell
        ggcStyleStatus.CellType = "ComboBox"
        ggcStyleStatus.DataSource = dt
        ggcStyleStatus.ValueMember = "id"
        ggcStyleStatus.DisplayMember = "name"
        ggcStyleStatus.DropDownStyle = GridDropDownStyle.Exclusive


        ListaAlmacen = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)
        'ListaAlmacen = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)

        Dim ggcStyle As GridTableCellStyleInfo = GridCompra.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = ListaAlmacen
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

    End Sub

    Public Sub GetProductosEntransito()
        listaProductos = compraSA.GetProductosEntransitoEquivalencia(New documentocompra With {
                                                                         .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                         .StatusEntregaProductosTransito = "1"
                                                                         })

    End Sub

    Sub LoadProductosTransito()
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("contenido")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("almacen")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("proveedor")
        dt.Columns.Add("status")
        dt.Columns.Add("sel", GetType(Boolean))
        dt.Columns.Add("costounitario")
        dt.Columns.Add("disponible")

        For Each i In listaProductos
            Dim costoUnitario = i.monto / i.cantidad

            dt.Rows.Add(
                i.idInventario,
                i.CustomProducto.origenProducto,
                i.CustomProducto.codigodetalle,
                i.CustomProducto.descripcionItem,
                i.CustomDetalleCompra.unidad1,
                i.CustomDetalleCompra.unidad2,
                i.cantidad,
                i.CustomDetalleCompra.tipoExistencia,
                ListaAlmacen.FirstOrDefault.idAlmacen,
                i.CustomDetalleCompra.documentocompra.tipoDoc,
                $"{i.CustomDetalleCompra.documentocompra.serie}-{i.CustomDetalleCompra.documentocompra.numeroDoc}",
                i.CustomDetalleCompra.documentocompra.entidad.nombreCompleto, "3", True, costoUnitario, i.cantidad)
        Next

        GridCompra.DataSource = dt
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Try
            If GridCompra.Table.Records.Count > 0 Then
                EnvioProductoTransitoRapido()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub EnvioProductoTransitoRapido()

        Dim ListaEnvios As New List(Of inventarioTransito)
        For Each r In GridCompra.Table.Records
            If r.GetValue("sel") = True Then
                ListaEnvios.Add(EntregaCompleta(r))
            End If
        Next
        If ListaEnvios.Count > 0 Then
            compraSA.EnvioProductosEnTransitoRapido(ListaEnvios)
            MessageBox.Show("productos enviados", "Enviío", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GetProductosEntransito()
            LoadProductosTransito()
            UCLogisticaAlmacen.ThreadTransito()
            'UCEntrega.formLogistica.ThreadTransito()
        End If
    End Sub

    Private Function EntregaCompleta(r As Record) As inventarioTransito
        EntregaCompleta = New inventarioTransito
        Dim obj As InventarioMovimiento
        Dim codigo = r.GetValue("codigo")
        Dim itemCompra = listaProductos.Where(Function(o) o.idInventario = codigo).SingleOrDefault

        Dim cantidadCompra = CDec(r.GetValue("disponible"))
        Dim cantidadActual = itemCompra.cantidad

        If cantidadActual <= 0 Then
            EntregaCompleta = New inventarioTransito
            Throw New Exception("Ingresar una cantidad valida!")
            Exit Function
        End If

        If cantidadActual > cantidadCompra Then
            EntregaCompleta = New inventarioTransito
            Throw New Exception("Ingresar una cantidad valida!")
            Exit Function
        End If


        Dim almacen = ListaAlmacen.Where(Function(o) o.idAlmacen = Integer.Parse(r.GetValue("almacen"))).SingleOrDefault

        If almacen.tipo = "AV" Then
            '  MessageBox.Show("Debe indicar un almacén de destino válido!", "Seleccionar almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EntregaCompleta = New inventarioTransito
            Throw New Exception("Debe indicar un almacén de destino válido!")
            Exit Function
        End If

        If r.GetValue("status") = "2" Then ' EN CURSO
            itemCompra.status = CInt(r.GetValue("status"))

            itemCompra.CustomDetalleCompra.inventarioTransito = New List(Of inventarioTransito) From
            {
            New inventarioTransito With
            {
            .idDocumentoCompra = itemCompra.CustomDetalleCompra.idDocumento,
            .secuencia = itemCompra.CustomDetalleCompra.secuencia,
            .idEstablecimiento = itemCompra.CustomDetalleCompra.documentocompra.idCentroCosto,
            .almacen = Integer.Parse(r.GetValue("almacen")),
            .idProducto = itemCompra.CustomProducto.codigodetalle,
            .cantidad = itemCompra.cantidad,
            .monto = itemCompra.monto,
            .montoME = itemCompra.montoME,
            .tipoOperacion = itemCompra.tipoOperacion,
            .status = 2
            }
            }
        ElseIf r.GetValue("status") = 3 Then 'ENTREGADO
            itemCompra.status = CInt(r.GetValue("status"))
        End If

        itemCompra.CustomListaInventario = New List(Of InventarioMovimiento)
        If itemCompra IsNot Nothing Then
            obj = New InventarioMovimiento
            obj.idorigenDetalle = itemCompra.CustomDetalleCompra.secuencia
            obj.idEmpresa = Gempresas.IdEmpresaRuc
            obj.idEstablecimiento = GEstableciento.IdEstablecimiento
            obj.idAlmacen = Integer.Parse(r.GetValue("almacen"))
            obj.TipoAlmacen = "AF"
            obj.nrolote = itemCompra.CustomDetalleCompra.codigoLote
            obj.tipoOperacion = itemCompra.tipoOperacion ' StatusTipoOperacion.COMPRA
            obj.tipoDocAlmacen = "99"
            obj.serie = itemCompra.CustomDetalleCompra.documentocompra.serie
            obj.numero = itemCompra.CustomDetalleCompra.documentocompra.numeroDoc
            obj.idDocumento = itemCompra.CustomDetalleCompra.documentocompra.idDocumento
            obj.idDocumentoRef = itemCompra.CustomDetalleCompra.documentocompra.idDocumento
            obj.descripcion = itemCompra.CustomProducto.descripcionItem
            obj.fechaLaboral = Date.Now
            obj.fecha = Date.Now
            obj.tipoRegistro = "E"
            obj.destinoGravadoItem = itemCompra.CustomProducto.origenProducto
            obj.tipoProducto = itemCompra.CustomProducto.tipoExistencia
            obj.OrigentipoProducto = "N"
            obj.idItem = itemCompra.CustomProducto.codigodetalle
            obj.marca = itemCompra.CustomProducto.unidad2
            obj.presentacion = itemCompra.CustomProducto.presentacion
            obj.cantidad = itemCompra.cantidad
            obj.unidad = itemCompra.CustomProducto.unidad1
            obj.cantidad2 = 0
            obj.precUnite = 0
            obj.precUniteUSD = 0
            obj.monto = itemCompra.monto ' montoCostoItem
            obj.montoUSD = itemCompra.montoME
            obj.montoOther = 0
            obj.monedaOther = 0
            obj.disponible = 0
            obj.disponible2 = 0
            obj.saldoMonto = 0
            obj.saldoMontoUsd = 0
            obj.status = "D"
            obj.entragado = r.GetValue("status")
            obj.usuarioActualizacion = usuario.IDUsuario
            obj.consignado = "N"
            obj.fechaActualizacion = Date.Now
            itemCompra.CustomListaInventario.Add(obj)


            '-------------------Salida del inventario -----------------------------
            '----------------------------------------------------------------------
            obj = New InventarioMovimiento
            obj.idorigenDetalle = itemCompra.CustomDetalleCompra.secuencia
            obj.idEmpresa = Gempresas.IdEmpresaRuc
            obj.idEstablecimiento = GEstableciento.IdEstablecimiento
            obj.idAlmacen = itemCompra.almacen ' itemCompra.CustomDetalleCompra.almacenRef
            obj.TipoAlmacen = "AF"
            obj.nrolote = itemCompra.CustomDetalleCompra.codigoLote
            obj.tipoOperacion = itemCompra.tipoOperacion 'StatusTipoOperacion.COMPRA
            obj.tipoDocAlmacen = "99"
            obj.serie = itemCompra.CustomDetalleCompra.documentocompra.serie
            obj.numero = itemCompra.CustomDetalleCompra.documentocompra.numeroDoc
            obj.idDocumento = itemCompra.CustomDetalleCompra.documentocompra.idDocumento
            obj.idDocumentoRef = itemCompra.CustomDetalleCompra.documentocompra.idDocumento
            obj.descripcion = itemCompra.CustomProducto.descripcionItem
            obj.fechaLaboral = Date.Now
            obj.fecha = Date.Now
            obj.tipoRegistro = "S"
            obj.destinoGravadoItem = itemCompra.CustomProducto.origenProducto
            obj.tipoProducto = itemCompra.CustomProducto.tipoExistencia
            obj.OrigentipoProducto = "N"
            obj.idItem = itemCompra.CustomProducto.codigodetalle
            obj.marca = itemCompra.CustomProducto.unidad2
            obj.presentacion = itemCompra.CustomProducto.presentacion
            obj.cantidad = itemCompra.cantidad * -1
            obj.unidad = itemCompra.CustomProducto.unidad1
            obj.cantidad2 = 0
            obj.precUnite = 0
            obj.precUniteUSD = 0
            obj.monto = itemCompra.monto * -1 ' montoCostoItem
            obj.montoUSD = itemCompra.montoME * -1
            obj.montoOther = 0
            obj.monedaOther = 0
            obj.disponible = 0
            obj.disponible2 = 0
            obj.saldoMonto = 0
            obj.saldoMontoUsd = 0
            obj.status = "D"
            obj.entragado = "S"
            obj.usuarioActualizacion = usuario.IDUsuario
            obj.consignado = "N"
            obj.fechaActualizacion = Date.Now
            itemCompra.CustomListaInventario.Add(obj)

            'EntregaCompleta.Add(itemCompra)
            EntregaCompleta = itemCompra
        End If
    End Function

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click

    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick
        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style3.Enabled Then
            If style3.TableCellIdentity.Column.Name = "cantidad" Then
                '       e.Inner.Cancel = True
                Dim disponible As Decimal = Decimal.Parse(style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("disponible").ToString()) 'Decimal.Parse(r.GetValue("disponible"))
                Dim value As String = style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim cantidad = InputBox("Rango disponible de [0 - " & disponible & "]", "Cantidad", 0)

                If cantidad.ToString.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.GridCompra.TableModel(e.Inner.RowIndex, 4).CellValue = 0
                    Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                    item.cantidad = 0
                    item.monto = 0
                    Exit Sub
                End If

                If IsNumeric(cantidad) Then
                    If cantidad > 0 Then
                        If cantidad > disponible Then
                            MessageBox.Show("Ingrese un cantidad menor o igual a: " & disponible, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.GridCompra.TableModel(e.Inner.RowIndex, 4).CellValue = 0
                            Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                            item.cantidad = 0
                            item.monto = 0
                        Else
                            Me.GridCompra.TableModel(e.Inner.RowIndex, 4).CellValue = Decimal.Parse(cantidad)
                            Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                            item.cantidad = Decimal.Parse(cantidad)
                            item.monto = Decimal.Parse(cantidad) * Decimal.Parse(style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("costounitario"))
                        End If
                    Else
                        MessageBox.Show("Ingrese un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.GridCompra.TableModel(e.Inner.RowIndex, 4).CellValue = 0
                        Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                        item.cantidad = 0
                        item.monto = 0
                    End If


                Else
                    Me.GridCompra.TableModel(e.Inner.RowIndex, 4).CellValue = 0
                    Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                    item.cantidad = 0
                    item.monto = 0
                End If

                'FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue, nomproduct)
                'FormInventarioCanastaTotales.validaStocks = True
                'FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
                'FormInventarioCanastaTotales.Show(Me)
            End If

        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "almacen" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            If text.Trim.Length > 0 Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                    Dim r = GridCompra.Table.CurrentRecord
                                    Dim item = listaProductos.Where(Function(o) o.idInventario = r.GetValue("codigo")).SingleOrDefault

                                    item.AlmacenEnvio = Integer.Parse(r.GetValue("almacen"))
                                End If
                            End If
                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "cantidad" Then
                    'If cc.Renderer IsNot Nothing Then

                    '    If e.TableControl.Model.Modified = True Then
                    '        Dim text As String = cc.Renderer.ControlText

                    '        If text.Trim.Length > 0 Then
                    '            If GridCompra.Table.CurrentRecord IsNot Nothing Then
                    '                Dim r = GridCompra.Table.CurrentRecord
                    '                Dim disponible As Decimal = Decimal.Parse(r.GetValue("disponible"))

                    '                If CDec(cc.Renderer.ControlText) > disponible Then
                    '                    r.SetValue("cantidad", 0)
                    '                    cc.RejectChanges()
                    '                    Me.GridCompra.TableModel(cc.RowIndex, 4).CellValue = 0
                    '                    cc.EndEdit()
                    '                    'Dim item = listaProductos.Where(Function(o) o.idInventario = r.GetValue("codigo")).SingleOrDefault
                    '                    'item.cantidad = 0
                    '                    'item.monto = 0
                    '                    'Me.GridCompra.EndUpdate(True)
                    '                    MessageBox.Show("Ingese una cantidad disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '                    Exit Sub
                    '                Else
                    '                    'Dim item = listaProductos.Where(Function(o) o.idInventario = r.GetValue("codigo")).SingleOrDefault
                    '                    'item.cantidad = Decimal.Parse(cc.Renderer.ControlText)
                    '                    'item.monto = Decimal.Parse(cc.Renderer.ControlText) * Decimal.Parse(r.GetValue("costounitario"))
                    '                End If
                    '            End If
                    '        End If
                    '    End If
                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub GridCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridCompra.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement


            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                Dim disponible As Decimal = Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("disponible").ToString()) 'Decimal.Parse(r.GetValue("disponible"))
                Dim cantidad As Decimal = Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cantidad").ToString())

                If item IsNot Nothing Then
                    'With e.TableCellIdentity.Table.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.ValidateValue
                    '    .NumberRequired = True
                    '    .Minimum = 0
                    '    .Maximum = disponible
                    '    .ErrorMessage = "Ingresar un cantidad menor o igual a: " & disponible
                    'End With



                    If cantidad > disponible Then
                        e.Style.Text = 0
                        item.cantidad = 0
                        item.monto = 0
                    Else
                        e.Style.Text = cantidad
                        'Dim item = listaProductos.Where(Function(o) o.idInventario = r.GetValue("codigo")).SingleOrDefault
                        item.cantidad = Decimal.Parse(cantidad)
                        item.monto = Decimal.Parse(cantidad) * Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("costounitario"))
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellValidated(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellValidated

    End Sub

    Private Sub GridCompra_TableControlCurrentCellValidating(sender As Object, e As GridTableControlCancelEventArgs) Handles GridCompra.TableControlCurrentCellValidating

    End Sub

    Private Sub UCMercaderiaEntransito_Load(sender As Object, e As EventArgs) Handles Me.Load
        GridCompra.TableModel.CellModels.Clear()
        GridCompra.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(GridCompra.TableModel))
        GridCompra.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"
    End Sub
#End Region

#Region "Events"

#End Region

End Class
