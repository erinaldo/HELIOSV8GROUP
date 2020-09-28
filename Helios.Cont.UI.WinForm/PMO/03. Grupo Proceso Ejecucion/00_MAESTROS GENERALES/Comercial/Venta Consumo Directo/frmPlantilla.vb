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
Public Class frmPlantilla
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGDetalle(dgPLantilla)
        GridCFG(dgvEntidadFinanciera)
    End Sub

#Region "Métodos"

    Public Sub GetPLantillasPadre(be As detalleitems)
        Dim plantillaSA As New articuloplantillaSA

        ListView1.Items.Clear()

        For Each i In plantillaSA.GetPlantillaPadre(be)
            Dim n As New ListViewItem(i.secuencia)
            n.SubItems.Add(i.descripcion)
            ListView1.Items.Add(n)
        Next

    End Sub


    Public Sub GetPLantillasByArticulo(be As articuloplantilla)
        Dim plantillaSA As New articuloplantillaSA
        Dim plantilla As New List(Of articuloplantilla)
        Dim dt As New DataTable
        Dim valPadre As Integer = 0

        dt.Columns.Add("idpadre")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("color")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("sec")

        plantilla = plantillaSA.GetPlantillaByIdPadre(be)
        If plantilla.Count > 0 Then
            valPadre = plantilla(0).idpadre
        End If
        Dim conteo As Integer = 1

        For Each i In plantilla
            If valPadre = i.idpadre Then

            Else
                valPadre = i.idpadre
                conteo = conteo + 1
            End If
            dt.Rows.Add(i.idpadre, "Platilla " & conteo, i.descripcion, i.cant, i.secuencia)
        Next
        dgPLantilla.DataSource = dt
        'dgPLantilla.TableDescriptor.GroupedColumns.Clear()
        'dgPLantilla.TableDescriptor.GroupedColumns.Add("descripcion")
    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()
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

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFGDetalle(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'GGC.TableOptions.SelectionBackColor = Color.Gray
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

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA

        Dim dt As New DataTable()
        dt.Columns.Add("idItem")
        dt.Columns.Add("producto")
        dt.Columns.Add("destino")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipoEx")

        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = (i.descripcionItem)
            dr(2) = (i.origenProducto)
            dr(3) = (i.unidad1)
            dr(4) = (i.tipoExistencia)
            dt.Rows.Add(dr)
        Next
        dgvEntidadFinanciera.DataSource = dt
        Me.dgvEntidadFinanciera.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
#End Region

    Private Sub frmPlantilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel1.Paint

    End Sub

    Private Sub txtSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarItem.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtBuscarItem.Text.Trim.Length > 0 Then
                ListaMercaderias(TipoExistencia.ProductoTerminado, txtBuscarItem.Text.Trim)
            Else
                MessageBoxAdv.Show("Debe describir el item a buscar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSubCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarItem.TextChanged

    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        ListView1.HideSelection = False
        ListView1.FullRowSelect = True
        Dim r As Record = dgvEntidadFinanciera.Table.CurrentRecord
        dgPLantilla.Table.Records.DeleteAll()
        If Not IsNothing(r) Then
            GetPLantillasPadre(New detalleitems With {.codigodetalle = Val(r.GetValue("idItem"))})
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New articuloplantilla
        Dim articuloSA As New articuloplantillaSA
        Dim r As Record
        r = dgvEntidadFinanciera.Table.CurrentRecord

        If Not IsNothing(r) Then
            If ListView1.SelectedItems.Count > 0 Then
                obj = New articuloplantilla

                obj.idarticulo = Val(r.GetValue("idItem"))
                obj.idpadre = Val(ListView1.SelectedItems(0).SubItems(0).Text)
                obj.descripcion = txtColor.Text.Trim
                obj.cant = 0
                articuloSA.InsertPlantillaArticulo(obj)
                MessageBox.Show("color agregado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetPLantillasByArticulo(New articuloplantilla With {.idpadre = ListView1.SelectedItems(0).SubItems(0).Text})
            Else

            End If

        Else

        End If

        Me.Cursor = Cursors.Arrow



    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If ListView1.SelectedItems.Count > 0 Then
            GetPLantillasByArticulo(New articuloplantilla With {.idpadre = ListView1.SelectedItems(0).SubItems(0).Text})
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New articuloplantilla
        Dim articuloSA As New articuloplantillaSA
        Dim r As Record
        r = dgvEntidadFinanciera.Table.CurrentRecord

        If Not IsNothing(r) Then
            obj = New articuloplantilla

            obj.idarticulo = Val(r.GetValue("idItem"))
            obj.idpadre = 0
            obj.descripcion = r.GetValue("producto")

            articuloSA.InsertPlantillaArticulo(obj)
            MessageBox.Show("Plantilla grabada!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GetPLantillasPadre(New detalleitems With {.codigodetalle = Val(r.GetValue("idItem"))})
        Else

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub dgPLantilla_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPLantilla.TableControlCellClick

    End Sub

    Private Sub dgPLantilla_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgPLantilla.TableControlCurrentCellEditingComplete
        Dim plantillaSA As New articuloplantillaSA
        Dim obj As New articuloplantilla
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgPLantilla.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 1 'color
                    e.TableControl.CurrentCell.EndEdit()
                    e.TableControl.Table.TableDirty = True
                    e.TableControl.Table.EndEdit()


                    Dim colCantidad As Decimal = 0
                    Dim sec As Integer = 0
                    obj = New articuloplantilla
                    colCantidad = CDec(dgPLantilla.Table.CurrentRecord.GetValue("cantidad"))
                    sec = CInt(dgPLantilla.Table.CurrentRecord.GetValue("sec"))

                    obj.secuencia = sec
                    obj.cant = colCantidad
                    obj.descripcion = dgPLantilla.Table.CurrentRecord.GetValue("color")

                    plantillaSA.EditarPlantillaArticulo(obj)

                Case 2 'cantidad

                    e.TableControl.CurrentCell.EndEdit()
                    e.TableControl.Table.TableDirty = True
                    e.TableControl.Table.EndEdit()

                    Dim colCantidad As Decimal = 0
                    Dim sec As Integer = 0
                    obj = New articuloplantilla
                    colCantidad = CDec(dgPLantilla.Table.CurrentRecord.GetValue("cantidad"))
                    sec = CInt(dgPLantilla.Table.CurrentRecord.GetValue("sec"))

                    obj.secuencia = sec
                    obj.cant = colCantidad
                    obj.descripcion = dgPLantilla.Table.CurrentRecord.GetValue("color")

                    plantillaSA.EditarPlantillaArticulo(obj)
            End Select
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim r As Record
        Dim SA As New articuloplantillaSA
        r = dgPLantilla.Table.CurrentRecord
        If Not IsNothing(r) Then
            SA.EliminarPlantillaArticulo(New articuloplantilla With {.secuencia = CInt(dgPLantilla.Table.CurrentRecord.GetValue("sec"))})
            dgPLantilla.Table.CurrentRecord.Delete()
        Else
            MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class