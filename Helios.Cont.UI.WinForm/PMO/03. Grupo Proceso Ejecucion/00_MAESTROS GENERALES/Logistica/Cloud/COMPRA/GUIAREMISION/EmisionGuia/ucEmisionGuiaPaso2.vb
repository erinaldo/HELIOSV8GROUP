Imports System.Drawing.Drawing2D
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class ucEmisionGuiaPaso2
    Private _formGuiaRemision8 As FormGuiaRemision8
    Private listaDetalle As List(Of documentoventaAbarrotesDet)
    Public listBienesAtrasladar As List(Of documentoventaAbarrotesDet)
    Public almacenSA As New almacenSA
    Private col2Check As Boolean = True
    Public Sub New(formGuiaRemision8 As FormGuiaRemision8)
        InitializeComponent()
        FormatGrid_DarkCell(gridDetalle, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.None)
        FormatGrid_DarkCell(GridBienesTraslados, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.None)

        Dim listaAlmacenes = GetDtAlmacenes()

        Me.gridDetalle.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.gridDetalle.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.DataSource = listaAlmacenes
        Me.gridDetalle.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.DisplayMember = "name"
        Me.gridDetalle.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.ValueMember = "id"
        Me.gridDetalle.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

        Me.GridBienesTraslados.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridBienesTraslados.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.DataSource = listaAlmacenes
        Me.GridBienesTraslados.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.DisplayMember = "name"
        Me.GridBienesTraslados.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.ValueMember = "id"
        Me.GridBienesTraslados.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

        _formGuiaRemision8 = formGuiaRemision8
        '      GetDetalleVenta()
        listBienesAtrasladar = New List(Of documentoventaAbarrotesDet)
    End Sub

    Private Function GetDtAlmacenes() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            dt.Rows.Add(i.idAlmacen, i.descripcionAlmacen)
        Next
        Return dt
    End Function

    Public Sub GetDetalleVenta()
        Dim dt = New DataTable("Productos x distribur")
        dt.Columns.Add("id")
        dt.Columns.Add("codigo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidad")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("contenido")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("cantdistribuida")
        dt.Columns.Add("saldo")
        dt.Columns.Add("cantTraslado")
        dt.Columns.Add("almacen")
        dt.Columns.Add("btagregar")

        Dim ventaSA As New documentoVentaAbarrotesDetSA


        listaDetalle = ventaSA.GetDetalleVentaGuiaSelventa(New documentoventaAbarrotesDet() With {.idDocumento = _formGuiaRemision8._venta.idDocumento})

        For Each i In listaDetalle ' _formGuiaRemision8._venta.documentoventaAbarrotesDet
            'Dim ventaItem = _formGuiaRemision8._venta.documentoventaAbarrotesDet

            dt.Rows.Add(i.secuencia, $"P-{i.idItem}", i.nombreItem, i.unidad1, i.nombreComercial, i.monto2, i.monto1, i.GetCantidadAcuenta, i.GetCantidadSaldo, 0, i.idAlmacenOrigen.GetValueOrDefault())
        Next
        gridDetalle.DataSource = dt
    End Sub

    Private Sub GridPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles gridDetalle.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 12 Then
                e.Inner.Style.Description = "Agregar"
                e.Inner.Style.TextColor = Color.LightGreen
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles gridDetalle.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 12 Then
                If gridDetalle.Table.CurrentRecord IsNot Nothing Then
                    If gridDetalle.Table.CurrentRecord IsNot Nothing Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)

                        If Decimal.Parse(style.TableCellIdentity.Table.CurrentRecord.GetValue("cantTraslado")) > 0 Then
                            Dim codigoVenta = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                            Dim ventaDet = listaDetalle.Where(Function(o) o.secuencia = codigoVenta).SingleOrDefault()

                            ventaDet.idAlmacenOrigen = Integer.Parse(style.TableCellIdentity.Table.CurrentRecord.GetValue("almacen"))
                            ventaDet.monto1 = Decimal.Parse(style.TableCellIdentity.Table.CurrentRecord.GetValue("cantTraslado"))
                            ventaDet.monto2 = Decimal.Parse(style.TableCellIdentity.Table.CurrentRecord.GetValue("contenido"))
                            ventaDet.nombreComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("unidadComercial")

                            ventaDet.AfectoInventario = True

                            Dim disponible As Decimal = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("saldo"))
                            If Decimal.Parse(style.TableCellIdentity.Table.CurrentRecord.GetValue("cantTraslado")) <= disponible Then
                                Dim existeItem = listBienesAtrasladar.Any(Function(i) i.secuencia = ventaDet.secuencia)
                                If existeItem Then
                                    MessageBox.Show("El bien ingresado ya está registrado, ingrese otro!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    listBienesAtrasladar.Add(ventaDet)
                                    MappingGridBienes()
                                End If
                            Else
                                MessageBox.Show("Ingrese una cantidad disponible!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Ingrese una cantidad mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If





                        'If venta IsNot Nothing Then
                        '    Dim f As New FormGuiaRemision8(venta)
                        '    f.StartPosition = FormStartPosition.CenterParent
                        '    f.ShowDialog(Me)
                        'End If

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MappingGridBienes()
        Dim dt = New DataTable("Lista de bienes x confirmar")
        dt.Columns.Add("id")
        dt.Columns.Add("codigo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("almacen")
        dt.Columns.Add("stock", GetType(Boolean))
        dt.Columns.Add("btdelete")

        For Each i In listBienesAtrasladar
            dt.Rows.Add(i.secuencia, $"P-{i.idItem}", i.nombreItem, i.unidad1, i.monto1, i.idAlmacenOrigen, i.AfectoInventario)
        Next

        GridBienesTraslados.DataSource = dt
    End Sub

    Private Sub GridBienesTraslados_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridBienesTraslados.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim cc As GridCurrentCell = GridBienesTraslados.TableControl.CurrentCell
        cc.ConfirmChanges()

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
            If style3.Enabled Then
                If style3.TableCellIdentity.Column.Name = "stock1" Then

                ElseIf style3.TableCellIdentity.Column.Name = "stock" Then
                    'Dim afectaStock = Me.GridBienesTraslados.TableModel(RowIndex, 18).CellValue
                    Dim afectaStock = style3.TableCellIdentity.Table.CurrentRecord.GetValue("stock")
                    Select Case afectaStock
                        Case "False" 'TRUE
                            If RowIndex <> -1 Then
                                Dim idItem = Integer.Parse(style3.TableCellIdentity.Table.CurrentRecord.GetValue("id"))
                                Dim item = listBienesAtrasladar.Where(Function(o) o.secuencia = idItem).SingleOrDefault()
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = True
                                    End With
                                End If
                            End If
                        Case Else ' FALSE
                            If RowIndex <> -1 Then
                                Dim idItem = Integer.Parse(style3.TableCellIdentity.Table.CurrentRecord.GetValue("id"))
                                Dim item = listBienesAtrasladar.Where(Function(o) o.secuencia = idItem).SingleOrDefault()
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

    Private Sub GridBienesTraslados_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridBienesTraslados.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 8 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.LightGreen
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridBienesTraslados_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridBienesTraslados.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 10 Then
                If GridBienesTraslados.Table.CurrentRecord IsNot Nothing Then
                    If GridBienesTraslados.Table.CurrentRecord IsNot Nothing Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                        Dim codigoVenta = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                        Dim ventaDet = listBienesAtrasladar.Where(Function(o) o.secuencia = codigoVenta).SingleOrDefault()

                        listBienesAtrasladar.Remove(ventaDet)

                        MappingGridBienes()
                        'If venta IsNot Nothing Then
                        '    Dim f As New FormGuiaRemision8(venta)
                        '    f.StartPosition = FormStartPosition.CenterParent
                        '    f.ShowDialog(Me)
                        'End If

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub sfButton1_Paint(sender As Object, e As PaintEventArgs) Handles sfButton1.Paint
        Dim radius As Integer = 5
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(Me.sfButton1.ClientRectangle.X + 1, Me.sfButton1.ClientRectangle.Y + 1, Me.sfButton1.ClientRectangle.Width - 2, Me.sfButton1.ClientRectangle.Height - 2)
        sfButton1.Region = New Region(GetRoundedRect(rect, radius))
        rect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2)
        e.Graphics.DrawPath(New Pen(Color.Green), GetRoundedRect(rect, radius))
    End Sub

    Private Sub SfButton2_Paint(sender As Object, e As PaintEventArgs) Handles SfButton2.Paint
        Dim radius As Integer = 5
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(Me.sfButton1.ClientRectangle.X + 1, Me.sfButton1.ClientRectangle.Y + 1, Me.sfButton1.ClientRectangle.Width - 2, Me.sfButton1.ClientRectangle.Height - 2)
        sfButton1.Region = New Region(GetRoundedRect(rect, radius))
        rect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2)
        e.Graphics.DrawPath(New Pen(Color.LightCoral), GetRoundedRect(rect, radius))
    End Sub

    Private Sub SfButton3_Paint(sender As Object, e As PaintEventArgs) Handles SfButton3.Paint
        Dim radius As Integer = 5
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(Me.sfButton1.ClientRectangle.X + 1, Me.sfButton1.ClientRectangle.Y + 1, Me.sfButton1.ClientRectangle.Width - 2, Me.sfButton1.ClientRectangle.Height - 2)
        sfButton1.Region = New Region(GetRoundedRect(rect, radius))
        rect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2)
        e.Graphics.DrawPath(New Pen(Color.FromKnownColor(KnownColor.HotTrack)), GetRoundedRect(rect, radius))
    End Sub

    Private Sub SfButton3_Click(sender As Object, e As EventArgs) Handles SfButton3.Click
        _formGuiaRemision8.sliderTop.Left = (_formGuiaRemision8.BunifuFlatButton3).Left
        _formGuiaRemision8.sliderTop.Width = (_formGuiaRemision8.BunifuFlatButton3).Width
        _formGuiaRemision8._ucEmisionGuiaPaso1.Visible = True
        _formGuiaRemision8._ucEmisionGuiaPaso2.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso3.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso4.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso5.Visible = False
    End Sub

    Private Sub sfButton1_Click(sender As Object, e As EventArgs) Handles sfButton1.Click 'salto al Paso 3
        If GridBienesTraslados.Table.Records.Count = 0 Then
            ErrorProvider1.SetError(Me.Label2, "Selecionar los bienes a trasladar")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.Label2, "")
        End If

        If TextPesoBruto.DecimalValue <= 0 Then
            ErrorProvider1.SetError(Me.TextPesoBruto, "Ingrese el peso total de los bienes")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.TextPesoBruto, "")
        End If

        _formGuiaRemision8.sliderTop.Left = (_formGuiaRemision8.BunifuFlatButton15).Left
        _formGuiaRemision8.sliderTop.Width = (_formGuiaRemision8.BunifuFlatButton15).Width
        _formGuiaRemision8._ucEmisionGuiaPaso1.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso2.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso4.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso5.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso3.Visible = True
    End Sub

    Private Sub SfButton2_Click(sender As Object, e As EventArgs) Handles SfButton2.Click
        _formGuiaRemision8.Close()
    End Sub

    Private Sub gridDetalle_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridDetalle.TableControlCellClick

    End Sub

    Private Sub gridDetalle_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles gridDetalle.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()



        Dim cr = e.TableControl.CurrentCell.Renderer
        Dim currentRecord = e.TableControl.Table.CurrentRecord


        'Dim dpac = currentRecord.GetValue("cbo")
        'Dim obj = (documentContractdetails)currentRecord.GetValue("detail")

        '    var prod = documentContractdetails.Where(o >= o.CodeAuth == obj.CodeAuth).SingleOrDefault();
        '    prod.product_type = dpac;
    End Sub

    Private Sub GridBienesTraslados_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridBienesTraslados.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim cr = e.TableControl.CurrentCell.Renderer
        Dim currentRecord = e.TableControl.Table.CurrentRecord

        ''Dim dpac = currentRecord.GetValue("cbo")
        Dim obj = listBienesAtrasladar.Where(Function(o) o.secuencia = Integer.Parse(currentRecord.GetValue("id"))).SingleOrDefault()
        obj.idAlmacenOrigen = Integer.Parse(currentRecord.GetValue("almacen"))

    End Sub

    Private Sub GridBienesTraslados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridBienesTraslados.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)

        If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "stock" Then
            Me.col2Check = Not Me.col2Check

            For Each i In GridBienesTraslados.Table.Records
                i.SetValue("stock", Me.col2Check)

                Dim item = listBienesAtrasladar.Where(Function(o) o.secuencia = i.GetValue("id")).SingleOrDefault
                If item IsNot Nothing Then
                    With item
                        .AfectoInventario = Me.col2Check
                    End With
                End If
            Next

            e.Inner.Cancel = True
        End If
    End Sub

    Private Sub GridBienesTraslados_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridBienesTraslados.QueryCellStyleInfo
        If e.TableCellIdentity IsNot Nothing Then
            If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "stock" Then
                e.Style.CellType = "CheckBox"
                e.Style.Description = e.Style.Text
                e.Style.CellValue = Me.col2Check
                e.Style.Enabled = True
            End If
        End If
    End Sub
End Class
