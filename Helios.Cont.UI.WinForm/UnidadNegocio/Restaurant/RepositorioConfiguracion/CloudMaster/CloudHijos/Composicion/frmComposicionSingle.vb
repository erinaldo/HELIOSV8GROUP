Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmComposicionSingle
    Implements IListaInventario

#Region "Attributes"
    Public Property EstadoManipulacion() As String
    Dim listaUM As New List(Of tabladetalle)
    Public Property listaServicio As New List(Of detalleitems)
    Public Property listaAreaOperativa As New List(Of areaOperativa)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of detalleitems))
    Public Property detalleitemsSA As New detalleitemsSA
    Public Alert As Alert

    Dim ListaProductos As New List(Of composicion)
    Public Property usercontrol As UserCanastaComposicion
    Dim popup As Popup
    Public Property listaCategoria As New List(Of detalleitems)
    Public Event OKEvent()

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.WindowState = FormWindowState.Normal
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvExistencias, False, 11.0F)
        GetTableGrid()

        bgCombos.RunWorkerAsync()

        usercontrol = New UserCanastaComposicion(Me)
        AddHandler usercontrol.OKEvent, AddressOf ucB_OKEvent
        popup = New Popup(usercontrol)
        popup.Resizable = True
    End Sub

    Public Sub New(ID As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        Me.WindowState = FormWindowState.Normal
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvExistencias, False, 11.0F)
        GetTableGrid()
        bgCombos.RunWorkerAsync()
        GetComposcion(ID)

        usercontrol = New UserCanastaComposicion(Me)
        AddHandler usercontrol.OKEvent, AddressOf ucB_OKEvent
        popup = New Popup(usercontrol)
        popup.Resizable = True


    End Sub
#End Region

    Public Sub ucB_OKEvent()
        popup.Hide()
        'Debug.Print("OK Event received from UserControl in FormB")
        RaiseEvent OKEvent()
    End Sub

    Public Sub AgregarProductoDetalleVenta(ID As Integer)
        Dim composicionBE As New composicion

        Dim producto = listaCategoria.Where(Function(o) o.codigodetalle = ID).SingleOrDefault

        If producto IsNot Nothing Then

            If (ListaProductos.Where(Function(o) o.idProducto = producto.codigodetalle).Count = 0) Then
                composicionBE.codigoDetalle = producto.codigodetalle
                composicionBE.descripcionComposicion = producto.descripcionItem
                composicionBE.origen = producto.origenProducto
                composicionBE.unidadMedida = producto.unidad1

                ListaProductos.Add(composicionBE)
                LoadCanastaVentas(ListaProductos)
            Else
                MessageBox.Show("YA EXISTE MA MATERIA PRIMA")
            End If

        End If


    End Sub

    Public Sub LoadCanastaVentas(lista As List(Of composicion))
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("origen")
        dt.Columns.Add("descripcionComposicion")
        dt.Columns.Add("unidadMedida")
        dt.Columns.Add("equivalencia")
        dt.Columns.Add("pumn")
        dt.Columns.Add("pume")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("estado")

        dgvExistencias.Table.Records.DeleteAll()
        For Each i In lista

            dt.Rows.Add(i.codigoDetalle,
                        i.origen,
                                i.descripcionComposicion,
                                i.unidadMedida,
                               i.equivalencia.GetValueOrDefault, i.pumn.GetValueOrDefault, 0, i.cantidad.GetValueOrDefault, i.importeMN.GetValueOrDefault, 0, "A")

        Next
        dgvExistencias.DataSource = dt
        dgvExistencias.Refresh()
    End Sub

    Sub cargar()

    End Sub


    Sub BuscarProducto(tipo As String)
        Try

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

            'ListaProductos = listaCategoria

            Dim StockTotal As Decimal = 0
            For Each i In Me.listaCategoria

                If i.detalleitem_equivalencias.Count > 0 Then
                    catalagoDefault = i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault
                Else
                    catalagoDefault = Nothing
                End If

                If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
                    Dim unidadMaxima = i.detalleitem_equivalencias.Max(Function(o) o.contenido_neto).GetValueOrDefault

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


            Next
            usercontrol.GridTotales.DataSource = dt
            usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetComposcion(ID As Integer)
        Dim composicionSA As New composicionSA
        Dim composicionBE As New composicion
        composicionBE.idEmpresa = Gempresas.IdEmpresaRuc
        composicionBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        composicionBE.idProducto = ID

        Dim varios = composicionSA.GetUbicarComposicionXId(composicionBE)
        For Each productoBE In varios
            With dgvExistencias.Table
                .AddNewRecord.SetCurrent()
                .AddNewRecord.BeginEdit()
                .CurrentRecord.SetValue("origen", productoBE.origen)
                .CurrentRecord.SetValue("equivalencia", productoBE.equivalencia)
                .CurrentRecord.SetValue("cantidad", productoBE.cantidad)
                .CurrentRecord.SetValue("descripcionComposicion", productoBE.descripcionComposicion)
                .CurrentRecord.SetValue("unidadMedida", productoBE.unidadMedida)
                .CurrentRecord.SetValue("pumn", productoBE.pumn)
                .CurrentRecord.SetValue("pume", productoBE.pume)
                .CurrentRecord.SetValue("importeMN", productoBE.importeMN)
                .CurrentRecord.SetValue("importeME", productoBE.importeME)
                .CurrentRecord.SetValue("estado", productoBE.estado)
                .AddNewRecord.EndEdit()
                .TableDirty = True
            End With
        Next

        If (varios.Count > 0) Then
            EstadoManipulacion = ENTITY_ACTIONS.UPDATE
        End If

    End Sub


    Public Sub EnviarListaArticulos(lista As List(Of totalesAlmacen)) Implements IListaInventario.EnviarListaArticulos
        'LimpiarProductosIguales(lista(0).idItem)
        For Each i In lista
            EnvioProductoSolo(i)
        Next

    End Sub

    Sub EnvioProductoSolo(productoBE As totalesAlmacen)
        '   Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0
            cantidad = productoBE.cantidad
            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME
            Dim existeEnCanasta = VerificarItemDuplicadoV2(CDec(cantidad), 0, productoBE.idItem)
            If existeEnCanasta Then

            Else

                With dgvExistencias.Table
                    .AddNewRecord.SetCurrent()
                    .AddNewRecord.BeginEdit()
                    .CurrentRecord.SetValue("destino", productoBE.origenRecaudo)
                    .CurrentRecord.SetValue("idItem", productoBE.idItem)
                    .CurrentRecord.SetValue("descripcionComposicion", productoBE.descripcion)
                    .CurrentRecord.SetValue("cantidad", cantidad)
                    .CurrentRecord.SetValue("unidadMedida", productoBE.idUnidad)
                    .CurrentRecord.SetValue("pumn", 0.0)
                    .CurrentRecord.SetValue("pumne", 0.0)
                    .CurrentRecord.SetValue("importeMN", 0.0)
                    .CurrentRecord.SetValue("importeME", 0.0)
                    .CurrentRecord.SetValue("idPres", productoBE.idAlmacen)
                    .CurrentRecord.SetValue("presentacion", productoBE.tipoExistencia)

                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    Private Function VerificarItemDuplicadoV2(cantidad As Decimal, lote As Integer, intIdItem As Integer) As Boolean
        VerificarItemDuplicadoV2 = False
        Dim colIdItem As Integer
        colIdItem = intIdItem

        For Each i In dgvExistencias.Table.Records
            If colIdItem = i.GetValue("idItem") Then
                'CalculosByCantidadExistente(cantidad, i)
                VerificarItemDuplicadoV2 = False
                Exit For
            End If
        Next
    End Function

    Sub grabarComposicion()
        Try
            If Label1.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(TextFiltrar, "Ingrese un servicio")
                'listaErrores += 1
                Exit Sub
            Else
                ErrorProvider1.SetError(TextFiltrar, Nothing)
            End If

            Dim obj As New composicion
            Dim composicionSA As New composicionSA
            Dim listaComposicion As New List(Of composicion)

            For Each item In dgvExistencias.Table.Records

                If CDec(item.GetValue("cantidad")) <= 0 Then
                    'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                    'Exit Sub
                End If

                If CDec(item.GetValue("pumn")) <= 0 Then
                    'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Throw New Exception("Debe ingresar un precio unitario mayor a cero.")
                    'Exit Sub
                End If

                If CDec(item.GetValue("descripcionComposicion").ToString.Length) <= 0 Then
                    'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Throw New Exception("Debe ingresar una descripción.")
                    'Exit Sub
                End If

                obj = New composicion
                obj.idProducto = Label1.Tag
                obj.[idEmpresa] = Gempresas.IdEmpresaRuc
                obj.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                obj.origen = CInt(item.GetValue("origen"))
                obj.[cantidad] = CDec(item.GetValue("cantidad"))
                obj.[descripcionComposicion] = item.GetValue("descripcionComposicion")
                obj.[unidadMedida] = item.GetValue("unidadMedida")
                obj.pumn = CDec(item.GetValue("pumn"))
                obj.pume = 0
                obj.equivalencia = CDec(item.GetValue("equivalencia"))
                obj.[importeMN] = CDec(item.GetValue("importeMN"))
                obj.[importeME] = 0
                obj.codigoDetalle = CInt(item.GetValue("ID"))
                obj.[estado] = "A"
                obj.[usuarioActualizacion] = usuario.IDUsuario
                obj.[fechaActualizacion] = Date.Now

                listaComposicion.Add(obj)
            Next

            composicionSA.SaveComposicionFull(listaComposicion)
            Alert = New Alert("composicion registrada", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetListaProductosTerminados(tipo As String)
        Dim dt As New DataTable
        Dim itemSA As New detalleitemsSA
        Dim itemBE As New detalleitems


        'itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        'itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        'itemBE.estado = "A"

        Select Case tipo
            Case "TODO"
                listaCategoria = itemSA.GetUbicarProductoXTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "03")
                'ListaProductos = listaCategoria
            Case "TEXTO"
                listaCategoria = listaCategoria.Where(Function(O) O.descripcionItem.Contains(TextFiltrar.Text)).ToList
        End Select



    End Sub

    Sub actualizarComposicion()
        Try
            If TextFiltrar.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(TextFiltrar, "Ingrese un servicio")
                'listaErrores += 1
                Exit Sub
            Else
                ErrorProvider1.SetError(TextFiltrar, Nothing)
            End If

            If TextFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                ErrorProvider1.SetError(TextFiltrar, Nothing)
            Else
                ErrorProvider1.SetError(TextFiltrar, "Ingrese un cliente válido")
                Exit Sub
                'listaErrores += 1
            End If

            Dim obj As New composicion
            Dim composicionSA As New composicionSA
            Dim listaComposicion As New List(Of composicion)
            Dim composicionBE As New composicion

            composicionBE.idEmpresa = Gempresas.IdEmpresaRuc
            composicionBE.idProducto = TextFiltrar.Tag

            For Each item In dgvExistencias.Table.Records

                If CDec(item.GetValue("cantidad")) <= 0 Then
                    'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                    'Exit Sub
                End If

                If CDec(item.GetValue("pumn")) <= 0 Then
                    'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Throw New Exception("Debe ingresar un precio unitario mayor a cero.")
                    'Exit Sub
                End If

                If CDec(item.GetValue("descripcionComposicion").ToString.Length) <= 0 Then
                    'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Throw New Exception("Debe ingresar una descripción.")
                    'Exit Sub
                End If

                obj = New composicion
                obj.idProducto = TextFiltrar.Tag
                obj.[idEmpresa] = Gempresas.IdEmpresaRuc
                obj.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                obj.[tipoInventario] = TipoExistencia.ProductoTerminado
                obj.[cantidad] = CDec(item.GetValue("cantidad"))
                obj.[descripcionComposicion] = item.GetValue("descripcionComposicion")
                obj.[unidadMedida] = item.GetValue("unidadMedida")
                obj.pumn = item.GetValue("pumn")
                obj.[pume] = item.GetValue("pume")
                obj.[importeMN] = item.GetValue("importeMN")
                obj.[importeME] = item.GetValue("importeME")
                obj.[observacion] = "Composicion con fecha:" & Date.Now
                obj.[estado] = "A"
                obj.[usuarioActualizacion] = usuario.IDUsuario
                obj.[fechaActualizacion] = Date.Now

                listaComposicion.Add(obj)
            Next

            composicionSA.UpdateComposicionFull(composicionBE, listaComposicion)
            Alert = New Alert("composicion registrada", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("descripcionComposicion", GetType(String))
        dt.Columns.Add("unidadMedida", GetType(String))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("equivalencia", GetType(Decimal))
        dt.Columns.Add("origen", GetType(Integer))

        dgvExistencias.DataSource = dt
    End Sub

    Private Sub EditarItemVenta(r As Record)
        If r IsNot Nothing Then

            Dim item = ListaProductos.Where(Function(o) o.codigoDetalle = r.GetValue("ID")).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .pumn = Decimal.Parse(r.GetValue("pumn"))
                    .cantidad = Decimal.Parse(r.GetValue("cantidad"))
                    .equivalencia = Decimal.Parse(r.GetValue("equivalencia"))
                    .importeMN = Decimal.Parse(r.GetValue("importeMN"))
                    .unidadMedida = r.GetValue("unidadMedida")
                End With
            End If
        End If

    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles TextFiltrar.TextChanged
        TextFiltrar.ForeColor = Color.Black
        TextFiltrar.Tag = Nothing
    End Sub

    Private Sub bgCombos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgCombos.DoWork
        Dim TablaSA As New tablaDetalleSA
        listaUM = TablaSA.GetListaTablaDetalle(6, "1")
    End Sub

    Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted

        Dim ggcStyle2 As GridTableCellStyleInfo = dgvExistencias.TableDescriptor.Columns(3).Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = listaUM
        ggcStyle2.ValueMember = "codigoDetalle2"
        ggcStyle2.DisplayMember = "descripcion"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive
        dgvExistencias.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvExistencias.ShowRowHeaders = False

    End Sub

    Private Sub frmServicioPrecios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        bgCombos.CancelAsync()
    End Sub



    Private Sub dgvExistencias_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvExistencias.TableControlCurrentCellEditingComplete
        Try
            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Select Case ColIndex
                Case 1
                    'Dim r As Record = dgvExistencias.Table.CurrentRecord

                    'Dim cantidad = CDec(r.GetValue("cantidad"))
                    'Dim pumn = r.GetValue("pumn")
                    'Dim total = pumn * cantidad
                    'Dim totalME = (total / TmpTipoCambio)
                    'Dim pume = pumn / TmpTipoCambio

                    'r.SetValue("importeMN", total)
                    'r.SetValue("importeME", totalME)
                    'r.SetValue("equivalencia", pume)

                    'EditarItemVenta(r)

                Case 4

                    Dim r As Record = dgvExistencias.Table.CurrentRecord

                    Dim cantidad = r.GetValue("cantidad")
                    Dim pumn = r.GetValue("pumn")
                    Dim Euivalencia = r.GetValue("equivalencia")

                    Dim total = (pumn * cantidad) / Euivalencia

                    r.SetValue("importeMN", total)


                    'Dim productoBE = ListaProductos.Where(Function(o) o.idProducto = r.GetValue("ID")).SingleOrDefault

                    EditarItemVenta(r)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub RoundButton24_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        If (Not IsNothing(dgvExistencias.Table.CurrentRecord)) Then
            dgvExistencias.Table.CurrentRecord.Delete()
        Else
            MessageBox.Show("Debe seleccionar un item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DgProductosTerminados_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs)
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 2 Then
                e.Inner.Style.Description = "Agregar"
                e.Inner.Style.TextColor = Color.Black

                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                              )
                'e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

        End If
    End Sub

    Private Sub DgProductosTerminados_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 2 Then

                Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()

                Dim existeEnCanasta = VerificarItemDuplicadoV2(CDec(1), 0, Record.GetValue("ID"))
                If existeEnCanasta Then

                Else

                    With dgvExistencias.Table
                        .AddNewRecord.SetCurrent()
                        .AddNewRecord.BeginEdit()
                        .CurrentRecord.SetValue("destino", "1")
                        .CurrentRecord.SetValue("idItem", Record.GetValue("ID"))
                        .CurrentRecord.SetValue("descripcionComposicion", Record.GetValue("descripcionComposicion"))
                        .CurrentRecord.SetValue("cantidad", 1)
                        .CurrentRecord.SetValue("unidadMedida", "")
                        .CurrentRecord.SetValue("pumn", 0.0)
                        .CurrentRecord.SetValue("pumne", 0.0)
                        .CurrentRecord.SetValue("importeMN", 0.0)
                        .CurrentRecord.SetValue("importeME", 0.0)
                        .CurrentRecord.SetValue("idPres", Nothing)
                        .CurrentRecord.SetValue("presentacion", "03")

                        .AddNewRecord.EndEdit()
                        .TableDirty = True
                    End With
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If (EstadoManipulacion = ENTITY_ACTIONS.INSERT) Then
            grabarComposicion()
        ElseIf (EstadoManipulacion = ENTITY_ACTIONS.UPDATE) Then
            actualizarComposicion()
        End If
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TextFiltrar.KeyDown

        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If TextFiltrar.Text.Trim.Length > 0 AndAlso TextFiltrar.Text.Trim.Length >= 2 Then
                    'PictureLoadingProduct.Visible = True

                    BuscarProducto("NOMBRE")

                    If listaCategoria.Count > 0 Then
                        popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))

                        Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                        Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                        Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)

                    Else
                    End If

                End If
            Else

            End If

            If e.KeyCode = Keys.Down Then

                If usercontrol.GridTotales.Table.Records.Count > 0 Then
                    popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                    Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                    Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                    Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                End If


            End If

            If e.KeyCode = Keys.Escape Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dgvExistencias_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvExistencias.TableControlCurrentCellChanged
        Try

            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "cantidad" Then
                        If cc.Renderer IsNot Nothing Then

                            If e.TableControl.Model.Modified = True Then
                                Dim text As String = cc.Renderer.ControlText

                                Dim r As Record = dgvExistencias.Table.CurrentRecord

                                If dgvExistencias.Table.CurrentRecord IsNot Nothing Then

                                    Dim cantidad = r.GetValue("cantidad")
                                    Dim pumn = r.GetValue("pumn")
                                    Dim Equivalencia = r.GetValue("equivalencia")

                                    Dim total = (pumn * cantidad) / Equivalencia

                                    r.SetValue("importeMN", total)

                                    EditarItemVenta(dgvExistencias.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)

                            End If
                        End If
                    ElseIf style.TableCellIdentity.Column.Name = "pumn" Then

                        If cc.Renderer IsNot Nothing Then

                            If e.TableControl.Model.Modified = True Then
                                Dim text As String = cc.Renderer.ControlText

                                Dim r As Record = dgvExistencias.Table.CurrentRecord

                                If dgvExistencias.Table.CurrentRecord IsNot Nothing Then

                                    Dim cantidad = r.GetValue("cantidad")
                                    Dim pumn = r.GetValue("pumn")
                                    Dim Equivalencia = r.GetValue("equivalencia")

                                    Dim total = (pumn * cantidad) / Equivalencia

                                    r.SetValue("importeMN", total)

                                    EditarItemVenta(dgvExistencias.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)

                            End If
                        End If

                    ElseIf style.TableCellIdentity.Column.Name = "equivalencia" Then
                        If cc.Renderer IsNot Nothing Then

                            If e.TableControl.Model.Modified = True Then
                                Dim text As String = cc.Renderer.ControlText

                                Dim r As Record = dgvExistencias.Table.CurrentRecord

                                If dgvExistencias.Table.CurrentRecord IsNot Nothing Then

                                    Dim cantidad = r.GetValue("cantidad")
                                    Dim pumn = r.GetValue("pumn")
                                    Dim Equivalencia = r.GetValue("equivalencia")

                                    Dim total = (pumn * cantidad) / Equivalencia

                                    r.SetValue("importeMN", total)

                                    EditarItemVenta(dgvExistencias.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)

                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class