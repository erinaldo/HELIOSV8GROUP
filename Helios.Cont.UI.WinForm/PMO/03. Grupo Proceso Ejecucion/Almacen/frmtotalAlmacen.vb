Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmtotalAlmacen
    Inherits frmMaster
    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Dim srtBusqueda As String
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarAlmacenes()
        SetRenderer()
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "RenderStyle"
    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        chAgrupa1.Renderer = styleRenderer1
        Dim styleRenderer2 As New StyledRenderer()
        chAgrupa2.Renderer = styleRenderer2
    End Sub
#End Region

#Region "Metodos"

    Private Sub CargarAlmacenes()
        Dim almacenSA As New almacenSA
        Dim tablaSA As New tablaDetalleSA

        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DataSource = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

    End Sub

    Private Function getParentTableTotalAlmacen(strTipoExistencia As String, strNomProducto As String) As DataTable
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos" & cboTipoExistencia.Text & " ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificicacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductoPorAlmacenTipoEx(txtAlmacen.ValueMember, strTipoExistencia, strNomProducto)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub BuscarProductoPorDescripcion()
        Dim parentTable As DataTable = getParentTableTotalAlmacen(cboTipoExistencia.SelectedValue, txtFiltro.Text.Trim)
        Me.dgvTotales.DataSource = parentTable
        dgvTotales.TableDescriptor.Relations.Clear()
        dgvTotales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvTotales.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvTotales.Appearance.AnyRecordFieldCell.Enabled = False
        dgvTotales.GroupDropPanel.Visible = True
        dgvTotales.TableDescriptor.GroupedColumns.Clear()
        dgvTotales.TableDescriptor.GroupedColumns.Add("Clasificicacion")
        '    Me.dgvTotales.TableDescriptor.VisibleColumns.Remove("Clasificicacion")
    End Sub
#End Region
#Region "Inventario"

    'Public Sub GrabarCierreinventario()

    '    Dim objCierreEO As New HeliosService.CierreinventarioEO()
    '    Try
    '        With objCierreEO
    '            .IdEmpresa = CEmpresa
    '            .IdEstablecimiento = CEstablecimiento
    '            .Periodo = String.Concat(Date.Now.Month, "/", Date.Now.Year)
    '            .IdAlmacen = cboalmacen.SelectedValue
    '            .IdItem = lsvTotales.SelectedItems(0).SubItems(1).Text
    '            .Anio = Date.Now.Year
    '            .Mes = Date.Now.Month
    '            .Dia = Date.Now.Day
    '            .Cantidad = lsvTotales.SelectedItems(0).SubItems(6).Text
    '            .Unidad = lsvTotales.SelectedItems(0).SubItems(4).Text
    '            .UsuarioModificacion = cIDUsuario
    '            .FechaModificacion = Date.Now
    '        End With
    '        If objService.GrabarCierreInventario(objCierreEO) Then
    '            MsgBox("Cierre de inventario: " & vbCrLf & "Grabado correctamente!", MsgBoxStyle.Information, "Done!")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al generar cierre de inventario." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
    '    End Try
    'End Sub

    Private Sub colorearColumnas_Listview(ByVal listview1 As System.Windows.Forms.ListView)

        For i As Integer = 0 To listview1.Items.Count - 1

            listview1.Items(i).UseItemStyleForSubItems = False

            If listview1.Items(i).SubItems.Count > 1 Then


                listview1.Items(i).SubItems(6).BackColor = Color.LightYellow
                listview1.Items(i).SubItems(6).ForeColor = Color.Black
                listview1.Items(i).SubItems(7).BackColor = Color.LavenderBlush
                listview1.Items(i).SubItems(7).ForeColor = Color.Black

                listview1.Items(i).SubItems(2).Font = New Font("Tahoma", 7, FontStyle.Bold, GraphicsUnit.Point)
                '  listview1.GridLines = True

            End If

        Next
    End Sub

    'Public Sub ObtenerTotales(ByVal intIdAlmacen As Integer)
    '    Dim objLista As New TotalesAlmacenSA
    '    Try
    '        lsvTotales.Columns.Clear()
    '        lsvTotales.Items.Clear()
    '        lsvTotales.GridLines = False
    '        lsvTotales.Columns.Add("Origen", 55) '0
    '        lsvTotales.Columns.Add("ID/item", 0) '01
    '        lsvTotales.Columns.Add("Producto/item", 220) '02
    '        lsvTotales.Columns.Add("Tipo Existencia", 75) '03
    '        lsvTotales.Columns.Add("IDU.M.", 0) '04
    '        lsvTotales.Columns.Add("U.M.", 100) '05
    '        lsvTotales.Columns.Add("Cantidad", 70) '06
    '        lsvTotales.Columns.Add("Importe", 100) '07

    '        For Each i As totalesAlmacen In objLista.GetListaProductosPorAlmacen(intIdAlmacen)
    '            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
    '            Dim n As New ListViewItem(i.origenRecaudo)
    '            n.SubItems.Add(i.idItem)
    '            n.SubItems.Add(i.descripcion)
    '            n.SubItems.Add(i.tipoExistencia)
    '            n.SubItems.Add(i.idUnidad)
    '            n.SubItems.Add(i.unidadMedida)
    '            n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '            n.SubItems.Add(FormatNumber(i.importeSoles, 2))
    '            lsvTotales.Items.Add(n)
    '        Next
    '        lblEstado.Text = "Registros encontrados: " & lsvTotales.Items.Count
    '        colorearColumnas_Listview(lsvTotales)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
#End Region

    Private Sub txtFiltro_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub frmtotalAlmacen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If filter IsNot Nothing Then
            filter.SaveCompareOperator()
        End If
        Dispose()
    End Sub

    Private Sub frmtotalAlmacen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If filter IsNot Nothing Then
            filter.LoadCompareOperator()
        End If
    End Sub


    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        'If lsvTotales.SelectedItems.Count > 0 Then
        '    With frmKardexDetails
        '        .LoadKardexProductos(cboalmacen.SelectedValue, lsvTotales.SelectedItems(0).SubItems(1).Text, lsvTotales.SelectedItems(0).SubItems(4).Text)
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '    End With
        'End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        'If lsvTotales.SelectedItems.Count > 0 Then
        '    GrabarCierreinventario()
        'Else
        '    MsgBox("Cierre de inventario: " & vbCrLf & "Seleccione un registro válido.", MsgBoxStyle.Information, "Atención!")
        'End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'datos.Clear()
        'With frmModalAlmacen
        '    .ObtenerAlmacenes(GEstableciento.IdEstablecimiento)
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIDAlmacen.Text = datos(0).ID
        '        txtAlmacen.Text = datos(0).NombreEntidad
        '        ObtenerTotales(txtIDAlmacen.Text)
        '    End If
        '    Me.Cursor = Cursors.Arrow
        'End With
    End Sub



    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        Dispose()
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.ValueMember = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
                '      ObtenerTotales(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        pcAlmacen.Font = New Font("Segoe UI", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
        If (dgvTotales.TableModel.RowCount > 0) Then
            ContextMenuStrip = New ContextMenuStrip()
            ContextMenuStrip.Items.Add("Ver proveedores")
            AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            AddHandler Me.dgvTotales.TableControlMouseDown, AddressOf dgvTotales_TableControlMouseDown
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvTotales.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Ver proveedores" Then
                If (Not IsNothing(Me.dgvTotales.Table.CurrentRecord.GetValue("idItem"))) Then
                    With frmTotalAlmacenDetalle
                        .txtAlmacen.Text = txtAlmacen.Text
                        .txtExistencias.Text = Me.dgvTotales.Table.CurrentRecord.GetValue("descripcion")
                        .BuscarProductoPorDescripcion(Me.dgvTotales.Table.CurrentRecord.GetValue("idItem"))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcAlmacen_Popup(sender As Object, e As EventArgs) Handles pcAlmacen.Popup
        lstAlmacen.Focus()
    End Sub

    Private Sub txtAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Down Then
            If Not Me.pcAlmacen.IsShowing() Then
                ' Let the popup align around the source textBox.
                pcAlmacen.Font = New Font("Segoe UI", 8)
                pcAlmacen.Size = New Size(260, 110)
                Me.pcAlmacen.ParentControl = Me.txtAlmacen
                Me.pcAlmacen.ShowPopup(Point.Empty)
                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.pcAlmacen.IsShowing() Then
                Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtAlmacen.Text.Trim.Length > 0 Then
                lblEstado.Text = "Debe elegir un almacén válido"
                Timer1.Enabled = True
                TiempoEjecutar(5)
            Else
                If txtFiltro.Text.Trim.Length > 0 Then
                    BuscarProductoPorDescripcion()
                    srtBusqueda = txtFiltro.Text
                Else
                    lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                    Timer1.Enabled = True
                    TiempoEjecutar(5)

                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chAgrupa1_ToggleStateChanged(sender As Object, e As Tools.ToggleStateChangedEventArgs) Handles chAgrupa1.ToggleStateChanged
        If chAgrupa1.ToggleState = Tools.ToggleButtonState.Active Then

            Me.dgvTotales.TopLevelGroupOptions.ShowFilterBar = True
            'Enable the filter for each columns 
            For i As Integer = 0 To dgvTotales.TableDescriptor.Columns.Count - 1
                dgvTotales.TableDescriptor.Columns(i).AllowFilter = True
            Next

        ElseIf chAgrupa1.ToggleState = Tools.ToggleButtonState.Inactive Then
            Me.dgvTotales.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub chAgrupa2_ToggleStateChanged(sender As Object, e As Tools.ToggleStateChangedEventArgs) Handles chAgrupa2.ToggleStateChanged
        If chAgrupa2.ToggleState = Tools.ToggleButtonState.Active Then
            filter.WireGrid(dgvTotales)
        ElseIf chAgrupa2.ToggleState = Tools.ToggleButtonState.Inactive Then
            filter.UnWireGrid(dgvTotales)
        End If
    End Sub

    Private Sub dgvTotales_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs) Handles dgvTotales.TableControlMouseDown
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvTotales.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvTotales.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvTotales.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub


    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cboTipoExistencia.SelectedIndex > -1 Then
            dgvTotales.Table.Records.DeleteAll()
            If Not txtAlmacen.Text.Trim.Length > 0 Then
                lblEstado.Text = "Debe elegir un almacén válido"
                Timer1.Enabled = True
                TiempoEjecutar(5)
            Else
                If txtFiltro.Text.Trim.Length > 0 Then
                    BuscarProductoPorDescripcion()
                Else
                    lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                    Timer1.Enabled = True
                    TiempoEjecutar(5)

                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReportTotalAlmacen
            .lblPerido.Text = PeriodoGeneral
            .ConsultaReporteTotalesPorPeriodo(txtAlmacen.ValueMember, txtAlmacen.Text, cboTipoExistencia.SelectedValue, srtBusqueda)
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()

        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvTotales_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvTotales.TableControlCellClick

    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Me.Cursor = Cursors.WaitCursor
        If Not txtAlmacen.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe elegir un almacén válido"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        Else
            If txtFiltro.Text.Trim.Length > 0 Then
                BuscarProductoPorDescripcion()
                srtBusqueda = txtFiltro.Text
            Else
                lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                Timer1.Enabled = True
                TiempoEjecutar(5)

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoExistencia_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia.Click

    End Sub
End Class