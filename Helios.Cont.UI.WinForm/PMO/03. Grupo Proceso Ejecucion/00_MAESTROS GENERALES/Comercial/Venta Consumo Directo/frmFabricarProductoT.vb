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
Public Class frmFabricarProductoT
    Inherits frmMaster
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetColumnMapping()
        LoadCombos()
        GridCFG(dgvProceso)
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
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

    Public Property ListaProductosByAlmacen() As List(Of totalesAlmacen)

#Region "Métodos"

    Function GetSumaByColumn(column As String) As Decimal
        Dim sum As Decimal = 0
        For Each i In dgvProceso.Table.Records
            sum += CDec(i.GetValue(column))
        Next
        Return sum
    End Function

    Public Sub LoadCombos()
        Dim almacenSA As New almacenSA

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

    Public Sub GetColumnMapping()
        Dim dt As New DataTable
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("cant")
        dt.Columns.Add("pu")
        dt.Columns.Add("costo")
        dt.Columns.Add("stock")
        dt.Columns.Add("requerido")

        dgvProceso.DataSource = dt

    End Sub
#End Region

    Private Sub frmFabricarProductoT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboAlmacen_Click(sender As Object, e As EventArgs) Handles cboAlmacen.Click

    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedIndexChanged
        Dim totalesSA As New TotalesAlmacenSA

        ListaProductosByAlmacen() = New List(Of totalesAlmacen)
        If Not IsNothing(cboAlmacen.SelectedValue) Then
            ListaProductosByAlmacen = totalesSA.GetListaProductosPorAlmacen(cboAlmacen.SelectedValue)
        End If

    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcProductos.Font = New Font("Segoe UI", 8)
            Me.pcProductos.Size = New Size(241, 110)
            Me.pcProductos.ParentControl = Me.txtBuscar
            Me.pcProductos.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListaProductosByAlmacen _
                     Where n.descripcion.StartsWith(txtBuscar.Text)).ToList

            lstProductos.DataSource = consulta
            lstProductos.DisplayMember = "descripcion"
            lstProductos.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcProductos.Font = New Font("Segoe UI", 8)
            Me.pcProductos.Size = New Size(241, 110)
            Me.pcProductos.ParentControl = Me.txtBuscar
            Me.pcProductos.ShowPopup(Point.Empty)
            lstProductos.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcProductos.IsShowing() Then
                Me.pcProductos.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        txtBuscar.ForeColor = Color.Black
        txtBuscar.Tag = Nothing
    End Sub

    Private Sub pcProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProductos.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstProductos.SelectedItems.Count > 0 Then
                txtBuscar.Text = lstProductos.Text
                txtBuscar.Tag = lstProductos.SelectedValue
                txtBuscar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                Dim obj = ListaProductosByAlmacen.Where(Function(o) o.idItem = Val(txtBuscar.Tag)).FirstOrDefault
                Dim pm As Decimal = 0
                If obj.cantidad > 0 Then
                    pm = obj.importeSoles / obj.cantidad
                Else
                    pm = 0
                End If

                Me.dgvProceso.Table.AddNewRecord.SetCurrent()
                Me.dgvProceso.Table.AddNewRecord.BeginEdit()
                Me.dgvProceso.Table.CurrentRecord.SetValue("idalmacen", cboAlmacen.SelectedValue)
                Me.dgvProceso.Table.CurrentRecord.SetValue("almacen", cboAlmacen.Text)
                Me.dgvProceso.Table.CurrentRecord.SetValue("iditem", txtBuscar.Tag)
                Me.dgvProceso.Table.CurrentRecord.SetValue("item", txtBuscar.Text)
                Me.dgvProceso.Table.CurrentRecord.SetValue("um", obj.unidadMedida)
                Me.dgvProceso.Table.CurrentRecord.SetValue("cant", 0)
                Me.dgvProceso.Table.CurrentRecord.SetValue("pu", pm)
                Me.dgvProceso.Table.CurrentRecord.SetValue("costo", 0)
                Me.dgvProceso.Table.CurrentRecord.SetValue("stock", obj.cantidad)
                Me.dgvProceso.Table.CurrentRecord.SetValue("requerido", 0)
                Me.dgvProceso.Table.AddNewRecord.EndEdit()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtBuscar.Focus()
        End If
    End Sub

    Private Sub lstProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstProductos.MouseDoubleClick
        If lstProductos.SelectedItems.Count > 0 Then
            Me.pcProductos.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProductos.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        Dim obj = ListaProductosByAlmacen.Where(Function(o) o.idItem = Val(txtBuscar.Tag)).FirstOrDefault
        Dim pm As Decimal = 0
        If obj.cantidad > 0 Then
            pm = obj.importeSoles / obj.cantidad
        Else
            pm = 0
        End If



        Me.dgvProceso.Table.AddNewRecord.SetCurrent()
        Me.dgvProceso.Table.AddNewRecord.BeginEdit()
        Me.dgvProceso.Table.CurrentRecord.SetValue("idalmacen", cboAlmacen.SelectedValue)
        Me.dgvProceso.Table.CurrentRecord.SetValue("almacen", cboAlmacen.Text)
        Me.dgvProceso.Table.CurrentRecord.SetValue("iditem", txtBuscar.Tag)
        Me.dgvProceso.Table.CurrentRecord.SetValue("item", txtBuscar.Text)
        Me.dgvProceso.Table.CurrentRecord.SetValue("um", obj.unidadMedida)
        Me.dgvProceso.Table.CurrentRecord.SetValue("cant", 0)
        Me.dgvProceso.Table.CurrentRecord.SetValue("pu", pm)
        Me.dgvProceso.Table.CurrentRecord.SetValue("costo", 0)
        Me.dgvProceso.Table.CurrentRecord.SetValue("stock", obj.cantidad)
        Me.dgvProceso.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmBusquedaExistencia
        f.cboTipoExistencia.Enabled = False
        f.cboTipoExistencia.SelectedValue = (TipoExistencia.ProductoTerminado)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, detalleitems)
            txtProductoTerminado.Text = c.descripcionItem
            txtProductoTerminado.Tag = c.idItem
            txtUMRQ.Text = c.unidad1
            txtTipoExRQ.Text = c.tipoExistencia
            txtCostoRequerido.DoubleValue = GetSumaByColumn("costo")
            txtCantRequerida.DoubleValue = GetSumaByColumn("cant")
        Else

        End If
    End Sub

    Private Sub dgvProceso_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProceso.TableControlCellClick

    End Sub

    Sub CalculoRequerido()
        Dim valRequerido As Decimal = 0
        Dim colCantidad As Decimal = 0
        For Each r In dgvProceso.Table.Records
            colCantidad = CDec(r.GetValue("cant"))
            valRequerido = colCantidad * txtPedido.DoubleValue
            r.SetValue("requerido", valRequerido.ToString("N2"))
        Next
    End Sub

    Sub calculo()
        Dim colCantidad As Decimal = 0
        Dim colPM As Decimal = 0
        Dim colCosto As Decimal = 0
        Dim disponible As Decimal = 0
        disponible = CDec(dgvProceso.Table.CurrentRecord.GetValue("stock"))
        colCantidad = CDec(dgvProceso.Table.CurrentRecord.GetValue("cant"))

        If colCantidad > disponible Then
            MessageBox.Show("Debe ingresar una cantidad menor o igual a la disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If colCantidad <= 0 Then
            dgvProceso.Table.CurrentRecord.SetValue("cant", 0)
            MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        colPM = CDec(dgvProceso.Table.CurrentRecord.GetValue("pu"))
        colCosto = colCantidad * colPM
        dgvProceso.Table.CurrentRecord.SetValue("costo", colCosto)

        txtCostoRequerido.DoubleValue = GetSumaByColumn("costo")
        txtCantRequerida.DoubleValue = GetSumaByColumn("cant")
    End Sub

    Private Sub dgvProceso_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvProceso.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvProceso.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 3
                    Dim colCantidad As Decimal = 0
                    Dim colPM As Decimal = 0
                    Dim colCosto As Decimal = 0
                    Dim disponible As Decimal = 0
                    disponible = CDec(dgvProceso.Table.CurrentRecord.GetValue("stock"))
                    colCantidad = CDec(dgvProceso.Table.CurrentRecord.GetValue("cant"))

                    If colCantidad > disponible Then
                        MessageBox.Show("Debe ingresar una cantidad menor o igual a la disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    If colCantidad <= 0 Then
                        dgvProceso.Table.CurrentRecord.SetValue("cant", 0)
                        MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    colPM = CDec(dgvProceso.Table.CurrentRecord.GetValue("pu"))
                    colCosto = colCantidad * colPM
                    dgvProceso.Table.CurrentRecord.SetValue("costo", colCosto)

                    txtCostoRequerido.DoubleValue = GetSumaByColumn("costo")
                    txtCantRequerida.DoubleValue = GetSumaByColumn("cant")
            End Select
        End If
    End Sub

    Private Sub btnFabricar_Click(sender As Object, e As EventArgs) Handles btnFabricar.Click
        Dim obj As New totalesAlmacen
        Dim lista As New List(Of totalesAlmacen)

        lista = New List(Of totalesAlmacen)

        obj = New totalesAlmacen

        obj.idAlmacen = cboAlmacen.SelectedValue
        obj.idItem = txtProductoTerminado.Tag
        obj.descripcion = txtProductoTerminado.Text
        obj.idUnidad = txtUMRQ.Text
        obj.tipoExistencia = txtTipoExRQ.Text
        obj.cantidad = 1
        obj.importeSoles = txtCostoRequerido.DoubleValue
        obj.TipoAcces = "PR"
        lista.Add(obj)

        For Each i In dgvProceso.Table.Records
            obj = New totalesAlmacen
            obj.idAlmacen = cboAlmacen.SelectedValue
            obj.idItem = Val(i.GetValue("iditem"))
            obj.descripcion = i.GetValue("item")
            obj.idUnidad = txtUMRQ.Text
            obj.tipoExistencia = TipoExistencia.MateriaPrima
            obj.cantidad = CDec(i.GetValue("cant"))
            obj.importeSoles = CDec(i.GetValue("costo"))
            obj.TipoAcces = "SC"
            obj.idItemPadre = txtProductoTerminado.Tag
            lista.Add(obj)
        Next

        Me.Tag = lista
        Close()

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
            dgvProceso.Table.CurrentRecord.Delete()
            txtCostoRequerido.DoubleValue = GetSumaByColumn("costo")
            txtCantRequerida.DoubleValue = GetSumaByColumn("cant")
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 1
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 3 / 4
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 2

                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
      
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 4
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 8
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 32
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CalculoRequerido()
    End Sub
End Class