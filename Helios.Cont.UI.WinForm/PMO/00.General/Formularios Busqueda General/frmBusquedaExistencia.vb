Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft
Imports Syncfusion.Grouping

Public Class frmBusquedaExistencia
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargarCombos()
        GridCFG(dgvEntidadFinanciera)
    End Sub

#Region "Métodos"

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA

        Dim dt As New DataTable()
        dt.Columns.Add("idItem")
        dt.Columns.Add("producto")
        dt.Columns.Add("destino")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("presentacion")

        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = (i.descripcionItem)
            dr(2) = (i.origenProducto)
            dr(3) = (i.unidad1)
            dr(4) = (i.tipoExistencia)
            dr(5) = (i.presentacion)
            dt.Rows.Add(dr)
        Next
        dgvEntidadFinanciera.DataSource = dt
        Me.dgvEntidadFinanciera.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub CargarCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim lista As New List(Of tabladetalle)

        lista = tablaSA.GetListaTablaDetalle(5, "1")
        Dim array() As String = {TipoExistencia.SubProductosDesechos, TipoExistencia.ProductoTerminado}

        Dim lista2 = (From n In lista _
                     Where array.Contains(n.codigoDetalle)).ToList


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = lista2

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()

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

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    'Sub GridCFG(GGC As GridGroupingControl)
    '    Dim colorx As New GridMetroColors()
    '    GGC.TableOptions.ShowRowHeader = False
    '    GGC.TopLevelGroupOptions.ShowCaption = False
    '    GGC.ShowColumnHeaders = True

    '    colorx = New GridMetroColors()
    '    colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
    '    colorx.HeaderTextColor.HoverTextColor = Color.Gray
    '    colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
    '    GGC.SetMetroStyle(colorx)
    '    GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

    '    '  GGC.BrowseOnly = True
    '    GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
    '    GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
    '    GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
    '    GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

    '    'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
    '    GGC.AllowProportionalColumnSizing = False
    '    GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    '    'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
    '    'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

    '    GGC.Table.DefaultColumnHeaderRowHeight = 45
    '    GGC.Table.DefaultRecordRowHeight = 40
    '    GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    'End Sub

#End Region

    Private Sub frmBusquedaExistencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmBusquedaExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If txtBuscarItem.Text.Trim.Length > 0 Then
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarItem.Text.Trim)
        Else
            MessageBoxAdv.Show("Debe describir el item a buscar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        '     Dispose()
    End Sub
    '//dgsdg
    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        If Not IsNothing(dgvEntidadFinanciera.Table.CurrentRecord) Then

            '------------------------------------------------------------------------------------



            Dim entidadSA As New entidadSA
            Dim tablaSA As New tablaDetalleSA
            Dim r As Record
            r = dgvEntidadFinanciera.Table.CurrentRecord

            ValidarItemsDuplicados(r.GetValue("idItem"))

            With frmNuevoCosto
                .dgvProductosTerminados.Table.AddNewRecord.SetCurrent()
                .dgvProductosTerminados.Table.AddNewRecord.BeginEdit()
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("idItem", r.GetValue("idItem"))
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("descripcion", r.GetValue("producto"))
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("tipoExistencia", r.GetValue("tipoEx"))
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("cantidad", 1)
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("pu", 0.0)
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("costo", 0.0)
                .dgvProductosTerminados.Table.CurrentRecord.SetValue("almacen", .CBOalmacenDestino.SelectedValue)
                .dgvProductosTerminados.Table.AddNewRecord.EndEdit()
                .dgvProductosTerminados.Table.ExpandAllRecords()
            End With
            MessageBox.Show("Artículo agregado a la canasta!", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            Dispose()
        End If
    End Sub

    Private Sub dgvEntidadFinanciera_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvEntidadFinanciera.MouseDoubleClick

    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellClick
        'Dim entidadSA As New entidadSA
        'Dim tablaSA As New tablaDetalleSA
        'Dim r As Record
        'If Not IsNothing(dgvEntidadFinanciera.Table.CurrentRecord) Then
        '    r = dgvEntidadFinanciera.Table.CurrentRecord
        '    With frmAportesInicio
        '        .dgvCompra.Table.AddNewRecord.SetCurrent()
        '        .dgvCompra.Table.AddNewRecord.BeginEdit()
        '        .dgvCompra.Table.CurrentRecord.SetValue("id", 0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("idModulo", r.GetValue("idItem"))
        '        .dgvCompra.Table.CurrentRecord.SetValue("Modulo", r.GetValue("producto"))
        '        .dgvCompra.Table.CurrentRecord.SetValue("unidad", tablaSA.GetUbicarTablaID(6, r.GetValue("unidad")).descripcion)
        '        .dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "MR")
        '        Select Case cboTipoExistencia.Text
        '            Case "MERCADERIA"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "20111") '
        '            Case "ACTIVO INMOVILIZADO"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "33") '
        '            Case "PRODUCTO TERMINADO"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "21") '
        '            Case "MATERIAS PRIMAS"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "24") '
        '            Case "ENVASES Y EMBALAJES"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "26") '

        '            Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "25") '
        '            Case "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "22") '
        '            Case "PRODUCTOS EN PROCESO"
        '                .dgvCompra.Table.CurrentRecord.SetValue("cuenta", "23") '

        '        End Select

        '        .dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        '        .dgvCompra.Table.CurrentRecord.SetValue("utiMenor", 0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("utiMayor", 0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("utiGranMayor", 0)
        '        .dgvCompra.Table.CurrentRecord.SetValue("destino", r.GetValue("destino"))
        '        .dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", r.GetValue("tipoEx"))
        '        .dgvCompra.Table.CurrentRecord.SetValue("colModVenta", False)
        '        .dgvCompra.Table.CurrentRecord.SetValue("valCheck", "N")
        '        .dgvCompra.Table.AddNewRecord.EndEdit()
        '        .dgvCompra.Table.ExpandAllRecords()
        '    End With
        '    '            Dispose()
        'End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim detalleItemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            ' .cboUnidades.SelectedValue = "07"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            ' .cboTipoExistencia.SelectedValue = "02"
            .Precios = True
            .IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            ButtonAdv2_Click(sender, e)
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
    End Sub
    Private Sub ValidarItemsDuplicados(intIdItem As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim colIdItem As Integer

        colIdItem = intIdItem
        With frmNuevoCosto
            For Each i In .dgvProductosTerminados.Table.Records
                If colIdItem = i.GetValue("idItem") Then
                    Throw New Exception("El artículo " & i.GetValue("descripcion") & ", ya se encuentra en la canasta. Ingrese otro")
                End If
            Next
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellDoubleClick
        Dim prod As New detalleitems

        Try
            If Not IsNothing(dgvEntidadFinanciera.Table.CurrentRecord) Then

                Dim entidadSA As New entidadSA
                Dim tablaSA As New tablaDetalleSA
                Dim r As Record
                r = dgvEntidadFinanciera.Table.CurrentRecord

                If Not IsNothing(r) Then
                    prod = New detalleitems
                    prod.codigodetalle = Val(r.GetValue("idItem"))
                    prod.descripcionItem = r.GetValue("producto")
                    prod.tipoExistencia = r.GetValue("tipoEx")
                    prod.unidad1 = r.GetValue("unidad")
                    prod.presentacion = r.GetValue("presentacion")

                    Me.Tag = prod
                    Close()
                End If

                'ValidarItemsDuplicados(r.GetValue("idItem"))

                'With frmNuevoCosto
                '    .dgvProductosTerminados.Table.AddNewRecord.SetCurrent()
                '    .dgvProductosTerminados.Table.AddNewRecord.BeginEdit()
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("idItem", r.GetValue("idItem"))
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("descripcion", r.GetValue("producto"))
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("tipoExistencia", r.GetValue("tipoEx"))
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("cantidad", 1)
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("pu", 0.0)
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("costo", 0.0)
                '    .dgvProductosTerminados.Table.CurrentRecord.SetValue("almacen", .CBOalmacenDestino.SelectedValue)
                '    .dgvProductosTerminados.Table.AddNewRecord.EndEdit()
                '    .dgvProductosTerminados.Table.ExpandAllRecords()
                'End With


                'MessageBox.Show("Artículo agregado a la canasta!", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvEntidadFinanciera.TableControlCurrentCellControlDoubleClick

    End Sub

    Private Sub txtBuscarItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ButtonAdv2_Click(sender, e)
        End If
    End Sub

    Private Sub txtBuscarItem_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarItem.TextChanged

    End Sub
End Class