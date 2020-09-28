Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmExistencias
    Inherits frmMaster

    Public ManipulacionEstado As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.panelDetalleItems.Width = 0
        txtBuscarClasif.Select()
        txtBuscarClasif.Focus()
        ListaEntradas()
    End Sub

#Region "Métodos"
    Public Sub ObtenerCategoriaPorID(intIdItem As Integer)
        Dim itemSA As New itemSA
        With itemSA.UbicarCategoriaPorID(intIdItem)
            txtFechaComprobante.Value = .fechaIngreso
            txtClasificacion.ValueMember = .idItem
            txtClasificacion.Text = .descripcion
            nudPorcentajeTributo.Value = .utilidad
        End With
    End Sub
#End Region

    Private Sub CompraDirectaConRecepciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDirectaConRecepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Me.panelDetalleItems.Width = 0
        Me.DockingManager1.DockControl(Me.PanelNuevoItem, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 300)
        'DockingManager1.DockControlInAutoHideMode(PanelNuevoItem, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 300)
        DockingManager1.SetDockVisibility(PanelNuevoItem, True)
        DockingManager1.SetDockVisibility(panelNuevoDetalleItem, False)
        DockingManager1.MDIActivatedVisibility = True
        DockingManager1.SetDockLabel(PanelNuevoItem, "Clasificación: Nuevo")
        DockingManager1.CloseEnabled = False
        ManipulacionEstado = ENTITY_ACTIONS.INSERT
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub btnAgregarClasificacion_Click(sender As Object, e As EventArgs) Handles btnAgregarClasificacion.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtClasificacion.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingresar una clasificacion")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not nudPorcentajeTributo.Value > 0 Then
                MessageBox.Show("Ingresar una utilidad")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                GrabarClasificacion()
            Else
                EditarClasificacion()
            End If

            DockingManager1.CloseEnabled = True
            txtClasificacion.Clear()
            nudPorcentajeTributo.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub GrabarClasificacion()
        Dim itemSA As New itemSA
        Dim item As New item
        Dim Returnitem As New item

        Try

            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcion = txtClasificacion.Text
                .fechaIngreso = DateTime.Now
                .utilidad = nudPorcentajeTributo.Value
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With
            Returnitem = itemSA.SaveCategoriaSL(item)
            If (Not IsNothing(Returnitem)) Then
                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", Returnitem.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", Returnitem.descripcion)
                Me.dgvCompra.Table.CurrentRecord.SetValue("utilidad", Returnitem.utilidad)
                Me.dgvCompra.Table.CurrentRecord.SetValue("fechaIngreso", Returnitem.fechaIngreso)
                Me.dgvCompra.Table.CurrentRecord.SetValue("estado", 1)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
                DockingManager1.SetDockVisibility(PanelNuevoItem, False)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub EditarClasificacion()
        Dim itemSA As New itemSA
        Dim item As New item
        Dim Returnitem As New item
        Try
            With item
                .idItem = txtClasificacion.ValueMember
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcion = txtClasificacion.Text
                .fechaIngreso = DateTime.Now
                .utilidad = nudPorcentajeTributo.Value
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With
            itemSA.UpdateCategoria(item)
            If (Not IsNothing(Returnitem)) Then
                '      Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", Returnitem.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", txtClasificacion.Text)
                Me.dgvCompra.Table.CurrentRecord.SetValue("utilidad", nudPorcentajeTributo.Value)
                Me.dgvCompra.Table.CurrentRecord.SetValue("fechaIngreso", txtFechaComprobante.Value)
                Me.dgvCompra.Table.CurrentRecord.SetValue("estado", 1)
                DockingManager1.SetDockVisibility(PanelNuevoItem, False)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GrabarExistencias()
        Dim detalleitemsSA As New detalleitemsSA
        Dim detalleitems As New detalleitems
        Try

            With detalleitems
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idItem = Me.dgvCompra.Table.CurrentRecord.GetValue("idItem")
                .cuenta = txtCodigoCuenta.Text
                .descripcionItem = txtExistencia.Text
                .presentacion = txtCodigoPresentación.Text
                .unidad1 = txtCodigoUnidad.Text
                .tipoExistencia = txtCodigoTExistencia.Text
                .origenProducto = 1
                .tipoProducto = 1
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With
            detalleitemsSA.InsertDetalle(detalleitems)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function getParentTableClasificacion(strIdempresa As String, intIdEstablecimiento As Integer) As DataTable
        Dim almacenSA As New itemSA

        Dim dt As New DataTable("clasificación - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("utilidad", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaIngreso", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As item In almacenSA.GetListaItemPorEmpresa(strIdempresa, intIdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaIngreso).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.utilidad
            dr(3) = str
            dr(4) = 1
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Private dtTableGrd As DataTable
    Public Sub ListaEntradas()
        Try
            Dim parentTable As DataTable = getParentTableClasificacion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            Me.dgvCompra.DataSource = parentTable
            dtTableGrd = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            '   dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            'PanelError.Visible = True
            'lblEstado.Text = "Lista de movimientos período: - " & PeriodoGeneral
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function getParentTableExistencias(intIdEstablecimiento As Integer, idItems As Integer) As DataTable
        Dim almacenSA As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable("Existencias ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("codigoDetalle", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idItem", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcionItem", GetType(String)))
        dt.Columns.Add(New DataColumn("presentación", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))

        For Each i As detalleitems In almacenSA.ListaProductosClasificados(intIdEstablecimiento, idItems)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.codigodetalle
            dr(1) = i.idItem
            dr(2) = i.cuenta
            dr(3) = i.descripcionItem
            dr(4) = i.presentacion
            dr(5) = i.unidad1
            Select Case i.tipoExistencia
                Case "01"
                    dr(6) = "MERCADERIA"
                Case "03"
                    dr(6) = "MATERIA PRIMA"
                Case "02"
                    dr(6) = "PRODUCTO TERMINADO"
                Case "04"
                    dr(6) = "ENVASES Y EMBALAJES"
                Case "05"
                    dr(6) = "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
                Case "06"
                    dr(6) = "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS"
                Case "07"
                    dr(6) = "PRODUCTOS EN PROCESO"
                Case "08"
                    dr(6) = "ACTIVO INMOVILIZADO"

            End Select
            ' tablaSA.GetUbicarTablaID(5, i.tipoExistencia).descripcion
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub ListaEntradasDetalleItems(strIdItems As Integer)
        Try
            Dim parentTable As DataTable = getParentTableExistencias(GEstableciento.IdEstablecimiento, strIdItems)
            Me.dgvDetalleItems.DataSource = parentTable
            dgvDetalleItems.TableDescriptor.Relations.Clear()
            dgvDetalleItems.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvDetalleItems.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvDetalleItems.Appearance.AnyRecordFieldCell.Enabled = False
            dgvDetalleItems.GroupDropPanel.Visible = True
            dgvDetalleItems.TableDescriptor.GroupedColumns.Clear()
            dgvDetalleItems.TableDescriptor.GroupedColumns.Add("tipoExistencia")
            dgvDetalleItems.Table.ExpandAllRecords()
            'For Each rec As Record In Me.dgvDetalleItems.Table.Records
            '    rec.IsExpanded = True
            'Next
            'PanelError.Visible = True
            'lblEstado.Text = "Lista de Existencias período: - " & PeriodoGeneral
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.panelDetalleItems.Width = 0
    End Sub


    Private Sub txtClasificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClasificacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudPorcentajeTributo.Select()
            nudPorcentajeTributo.Focus()
        End If
    End Sub

    Private Sub nudPorcentajeTributo_MouseDown(sender As Object, e As MouseEventArgs) Handles nudPorcentajeTributo.MouseDown
        If e.Clicks = Keys.Enter Then
            btnAgregarClasificacion.Select()
            btnAgregarClasificacion.Focus()
        End If
    End Sub

    Private Sub txtExistencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtExistencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtUnidad.Select()
        End If
    End Sub

    Private Sub txtUnidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtPresentacion.Select()
        End If
    End Sub

    Private Sub txtPresentacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPresentacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtPresentacion.Select()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtExisClasificacion.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingresar una clasificacion")
                '    lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtExistencia.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingresar una clasificacion")
                '   lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                GrabarExistencias()
                DockingManager1.CloseEnabled = True
                txtExistencia.Clear()
            Else
                UpdateCompra()
                DockingManager1.SetDockVisibility(panelNuevoDetalleItem, False)

                '    Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                MessageBox.Show("Selecione un campo")
            End If


        Catch ex As Exception
            '   lblEstado.Text = ex.Message
            '   lblEstado.Image = My.Resources.warning2
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub ObtenerListaControlesLoad()
        txtCodigoPresentación.Text = "09"
        txtTipoExitencia.Text = "MERCADERIA"
        txtCodigoUnidad.Text = "07"
        txtPresentacion.Text = "UNIDADES"
        txtUnidad.Text = "UND"
        txtCodigoCuenta.Text = "601111"
        txtCuenta.Text = "Costo"
        txtTipoExitencia.Text = "01"
    End Sub

    Private Sub ExistenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExistenciasToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            With frmNuevaExistencia
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe seleccinar una clasificación válida!", "Atención", Nothing, MessageBoxIcon.Error)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged

    End Sub

    Private Sub dgvCompra_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanging

    End Sub


    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                Dim detalleitemSA As New detalleitemsSA
                DockingManager1.SetDockVisibility(panelNuevoDetalleItem, False)
                DockingManager1.SetDockVisibility(PanelNuevoItem, False)
                Me.panelDetalleItems.Width = 270
                ListaEntradasDetalleItems(Me.dgvCompra.Table.CurrentRecord.GetValue("idItem"))
            End If
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarClasif_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarClasif.TextChanged
        dtTableGrd.DefaultView.RowFilter = "descripcion Like '%" & txtBuscarClasif.Text & "%'"
    End Sub

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            ListaEntradasDetalleItems(Me.dgvCompra.Table.CurrentRecord.GetValue("idItem"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RemoveClasifiacion(strIdItem As Integer)
        Dim itemSA As New itemSA
        Dim objitem As New item

        With objitem
            .idItem = strIdItem
        End With

        If (itemSA.DeleteCategoriaSL(objitem) = True) Then
            '     lblEstado.Text = "No se puede eliminar la clasifiacion"
        Else
            Me.dgvCompra.Table.CurrentRecord.Delete()
            'PanelError.Visible = True
            'lblEstado.Text = "Clasifiación eliminada!"
        End If
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        ListaEntradas()
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub UpdateCompra()
        Dim itemSA As New detalleitemsSA
        Dim objItem As New detalleitems

        With objItem
            .codigodetalle = Me.dgvDetalleItems.Table.CurrentRecord.GetValue("codigoDetalle")
            .idItem = Me.dgvCompra.Table.CurrentRecord.GetValue("idItem")
            .cuenta = txtCodigoCuenta.Text
            .presentacion = txtCodigoPresentación.Text
            .unidad1 = txtCodigoUnidad.Text
            .tipoExistencia = txtCodigoTExistencia.Text
            .descripcionItem = txtExistencia.Text
            .origenProducto = 1
            .tipoProducto = 1
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = Date.Now
        End With

        itemSA.UpdateProducto(objItem)

    End Sub

    Private Sub frmExistencias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmExistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Editar")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Try
            If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                If e.ClickedItem.Text = "Editar" Then
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        Me.Cursor = Cursors.WaitCursor
                        DockingManager1.SetDockVisibility(PanelNuevoItem, True)
                        DockingManager1.DockControl(PanelNuevoItem, Me, Tools.DockingStyle.Left, 300)
                        DockingManager1.SetDockLabel(PanelNuevoItem, "Clasificación: Edición")
                        ObtenerCategoriaPorID(Me.dgvCompra.Table.CurrentRecord.GetValue("idItem"))
                        ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    Else
                        MessageBox.Show("Seleccione una clasificación")
                    End If
                Else
                    MessageBox.Show("Seleccione una existencia")
                End If

                Me.Cursor = Cursors.Arrow
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
    
    End Sub
End Class