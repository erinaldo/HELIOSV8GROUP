Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmComposicion
    Implements IListaInventario

#Region "Attributes"
    Public Property EstadoManipulacion() As String
    Dim listaUM As New List(Of tabladetalle)
    Public Property listaServicio As New List(Of detalleitems)
    Public Property listaAreaOperativa As New List(Of areaOperativa)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of detalleitems))
    Public Property detalleitemsSA As New detalleitemsSA
    Public Alert As Alert

    Dim ListaProductos As New List(Of detalleitems)

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
    End Sub

    Public Sub New(ID As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        Me.WindowState = FormWindowState.Normal
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvExistencias, False, 11.0F)
        FormatoGridPequeño(dgProductosTerminados, False, 11.0F)
        GetTableGrid()
        bgCombos.RunWorkerAsync()
        GetComposcion(ID)

    End Sub
#End Region

    Private Sub GetComposcion(ID As Integer)
        Dim composicionSA As New composicionSA
        Dim composicionBE As New composicion
        composicionBE.idEmpresa = Gempresas.IdEmpresaRuc
        composicionBE.idProducto = ID

        Dim varios = composicionSA.GetUbicarComposicion(composicionBE)
        For Each productoBE In varios
            With dgvExistencias.Table
                .AddNewRecord.SetCurrent()
                .AddNewRecord.BeginEdit()
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
            If TXTcOMPRADOR.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un servicio")
                'listaErrores += 1
                Exit Sub
            Else
                ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
            End If

            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
            Else
                ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                Exit Sub
                'listaErrores += 1
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
                obj.idProducto = TXTcOMPRADOR.Tag
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

            composicionSA.SaveComposicionFull(listaComposicion)
            Alert = New Alert("composicion registrada", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetListaProductosTerminados(tipo As String)
        Dim dt As New DataTable
        Dim itemSA As New detalleitemsSA
        Dim itemBE As New detalleitems
        Dim listaCategoria As New List(Of detalleitems)

        'itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        'itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        'itemBE.estado = "A"

        Select Case tipo
            Case "TODO"
                listaCategoria = itemSA.GetUbicarProductoXTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "03")
                ListaProductos = listaCategoria
            Case "TEXTO"
                listaCategoria = ListaProductos.Where(Function(O) O.descripcionItem.Contains(TXTcOMPRADOR.Text)).ToList
        End Select

        dgProductosTerminados.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcionComposicion")
            .Add("estado")
        End With

        For Each i In listaCategoria

            dt.Rows.Add(i.codigodetalle,
                    i.descripcionItem,
                    "")
        Next
        dgProductosTerminados.DataSource = dt

    End Sub

    Sub actualizarComposicion()
        Try
            If TXTcOMPRADOR.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un servicio")
                'listaErrores += 1
                Exit Sub
            Else
                ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
            End If

            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
            Else
                ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                Exit Sub
                'listaErrores += 1
            End If

            Dim obj As New composicion
            Dim composicionSA As New composicionSA
            Dim listaComposicion As New List(Of composicion)
            Dim composicionBE As New composicion

            composicionBE.idEmpresa = Gempresas.IdEmpresaRuc
            composicionBE.idProducto = TXTcOMPRADOR.Tag

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
                obj.idProducto = TXTcOMPRADOR.Tag
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

        dgvExistencias.DataSource = dt
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
    End Sub

    Private Sub bgCombos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgCombos.DoWork
        Dim TablaSA As New tablaDetalleSA
        listaUM = TablaSA.GetListaTablaDetalle(6, "1")
    End Sub

    Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted
        'Dim dt As New DataTable
        'dt.Columns.Add("ID")
        'dt.Columns.Add("NAME")
        'dt.Rows.Add(1, "1 - GRAVADO")
        'dt.Rows.Add(2, "2 - EXONERADO")
        'dt.Rows.Add(3, "3 - INAFECTO")

        'Dim ggcStyle As GridTableCellStyleInfo = dgvExistencias.TableDescriptor.Columns(4).Appearance.AnyRecordFieldCell
        'ggcStyle.CellType = "ComboBox"
        'ggcStyle.DataSource = dt
        'ggcStyle.ValueMember = "ID"
        'ggcStyle.DisplayMember = "NAME"
        'ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        'dgvExistencias.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        'dgvExistencias.ShowRowHeaders = False

        Dim ggcStyle2 As GridTableCellStyleInfo = dgvExistencias.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
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

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs)

        'With FormInventCanastaComposicion
        '    .txtFiltrar.Focus()
        '    .txtFiltrar.Select(0, .txtFiltrar.Text.Length)
        '    .TextCodigoBarra.Clear()
        '    .validaSelPrecioVenta = True
        '    '.chCantidadPrevia.Checked = True
        '    .StartPosition = FormStartPosition.CenterScreen
        '    ' .Show(Me)
        '    .ShowDialog(Me)
        '    If dgvExistencias.Table.Records.Count > 0 Then
        '        'dgvCompra.Focus()
        '        Me.dgvExistencias.TableControl.CurrentCell.MoveTo(dgvExistencias.Table.Records.Count - 1, 7, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
        '        dgvExistencias.Table.Records(dgvExistencias.Table.Records.Count - 1).SetCurrent()
        '        dgvExistencias.Table.Records(dgvExistencias.Table.Records.Count - 1).BeginEdit()
        '        Me.ActiveControl = Me.dgvExistencias.TableControl
        '        dgvExistencias.WantTabKey = True
        '    End If
        'End With

    End Sub

    Private Sub dgvExistencias_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvExistencias.TableControlCurrentCellEditingComplete

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            Select Case ColIndex
                Case 1
                    Dim r As Record = dgvExistencias.Table.CurrentRecord

                    Dim cantidad = CDec(r.GetValue("cantidad"))
                    Dim pumn = r.GetValue("pumn")
                    Dim total = pumn * cantidad
                    Dim totalME = (total / TmpTipoCambio)
                    Dim pume = pumn / TmpTipoCambio

                    r.SetValue("importeMN", total)
                    r.SetValue("importeME", totalME)
                    r.SetValue("pume", pume)

                Case 4

                    Dim r As Record = dgvExistencias.Table.CurrentRecord

                    Dim cantidad = r.GetValue("cantidad")
                    Dim pumn = r.GetValue("pumn")
                    Dim total = pumn * cantidad
                    Dim totalME = (total / TmpTipoCambio)
                    Dim pume = pumn / TmpTipoCambio

                    r.SetValue("importeMN", total)
                    r.SetValue("importeME", totalME)
                    r.SetValue("pume", pume)
                    'Dim pagos As Decimal = pumn()

                    'lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

                    'If (lblPagoVenta.Text = CDec(0.0)) Then
                    '    ErrorProvider1.Clear()
                    'End If

                    'If pagos > CDec(txtTotalPagar.Text) Then
                    '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                    '    Exit Sub
                    'End If
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

    Private Sub DgProductosTerminados_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgProductosTerminados.TableControlDrawCell
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

    Private Sub DgProductosTerminados_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgProductosTerminados.TableControlPushButtonClick
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

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If TXTcOMPRADOR.Text.Trim.Length > 0 AndAlso TXTcOMPRADOR.Text.Trim.Length >= 2 Then
                    GetListaProductosTerminados("TEXTO")
                ElseIf TXTcOMPRADOR.Text.Trim.Length = 0 Then
                    GetListaProductosTerminados("TODO")
                End If
                If e.KeyCode = Keys.Down Then

                    'usercontrol.GridTotales.TableControl.CurrentCell.ShowDropDown()
                End If            '   End If

                ' e.SuppressKeyPress = True
                If e.KeyCode = Keys.Escape Then

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvExistencias_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvExistencias.TableControlCellClick

    End Sub
End Class