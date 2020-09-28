Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.WinForms.DataGrid.Events
Imports Syncfusion.WinForms.Controls

Public Class ucInventarioMinimo
    Public Property listaInventario As List(Of totalesAlmacen)
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        LoadCombos()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region

#Region "Methods"
    Private Sub LoadCombos()
        Dim almacenSA As New almacenSA
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = GetExistencias()

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub

    Private Sub GetInventario(be As totalesAlmacen)
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("unidadNegocio", GetType(String)))
        dt.Columns.Add(New DataColumn("almacen", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))

        dt.Columns.Add(New DataColumn("stockminimo", GetType(String)))
        dt.Columns.Add(New DataColumn("stock", GetType(String)))

        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoexistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("ID", GetType(Integer)))

        listaInventario = New List(Of totalesAlmacen)
        listaInventario = TotalesAlmacenSA.GetInventarioGeneral(be).OrderBy(Function(o) o.descripcion).ToList
        Dim minCantidad = listaInventario.Max(Function(o) o.cantidadMinima)
        minCantidad = minCantidad + 5

        For Each i As totalesAlmacen In listaInventario.Where(Function(o) o.cantidad <= minCantidad).ToList 'TotalesAlmacenSA.GetInventarioGeneral(be).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.NombreEstablecimiento
            dr(1) = i.NomAlmacen
            dr(2) = i.descripcion
            dr(3) = i.cantidadMinima.GetValueOrDefault
            dr(4) = i.cantidad
            dr(5) = i.unidadMedida
            dr(6) = strGravado
            dr(7) = i.tipoExistencia
            dr(8) = i.idItem
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)

        ''dgvKardexVal.DataSource = dt
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '''''ComboStatus()
    End Sub

    Private Sub GetInventario2(be As totalesAlmacen)
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("unidadNegocio", GetType(String)))
        dt.Columns.Add(New DataColumn("almacen", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))

        dt.Columns.Add(New DataColumn("stockminimo", GetType(String)))
        dt.Columns.Add(New DataColumn("stock", GetType(String)))

        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoexistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("ID", GetType(Integer)))

        listaInventario = New List(Of totalesAlmacen)
        listaInventario = TotalesAlmacenSA.GetInventarioGeneral(be).OrderBy(Function(o) o.descripcion).ToList
        Dim minCantidad = listaInventario.Max(Function(o) o.cantidadMinima)
        minCantidad = minCantidad + 5

        For Each i As totalesAlmacen In listaInventario.Where(Function(o) o.cantidad <= minCantidad).ToList 'TotalesAlmacenSA.GetInventarioGeneral(be).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.NombreEstablecimiento
            dr(1) = i.NomAlmacen
            dr(2) = i.descripcion
            dr(3) = i.cantidadMinima.GetValueOrDefault
            dr(4) = i.cantidad
            dr(5) = i.unidadMedida
            dr(6) = strGravado
            dr(7) = i.tipoExistencia
            dr(8) = i.idItem
            dt.Rows.Add(dr)
        Next
        sfDataGrid.DataSource = dt
        '   PictureLoad.Visible = False
        Me.sfDataGrid.ShowBusyIndicator = False
        BunifuFlatButton4.Enabled = True

        'Dim minCantidad = listaInventario.Max(Function(o) o.cantidadMinima)
        'minCantidad = minCantidad + 5

        Dim minCantidadRequerimiento = listaInventario.Max(Function(o) o.cantidadMinima)
        minCantidadRequerimiento = minCantidadRequerimiento - 5

        Dim SinStock As Decimal = listaInventario.Where(Function(o) o.cantidad <= 0).Count
        Dim stockRequeri As Decimal = listaInventario.Where(Function(o) o.cantidad < o.cantidadMinima And o.cantidad > 0).Count
        Dim stockMinimo As Decimal = listaInventario.Where(Function(o) o.cantidad = o.cantidadMinima).Count
        Dim stockBase As Decimal = listaInventario.Where(Function(o) o.cantidad > o.cantidadMinima AndAlso o.cantidad <= minCantidad).Count

        Label2.Text = SinStock
        Label5.Text = stockRequeri
        Label6.Text = stockMinimo
        Label7.Text = stockBase

        ''dgvKardexVal.DataSource = dt
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '''''ComboStatus()
    End Sub

    Private Sub GetInventarioGuia(lista As List(Of totalesAlmacen))
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("unidadNegocio", GetType(String)))
        dt.Columns.Add(New DataColumn("almacen", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))

        dt.Columns.Add(New DataColumn("stockminimo", GetType(String)))
        dt.Columns.Add(New DataColumn("stock", GetType(String)))

        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoexistencia", GetType(String)))


        For Each i As totalesAlmacen In lista 'TotalesAlmacenSA.GetInventarioGeneral(be).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.NombreEstablecimiento
            dr(1) = i.NomAlmacen
            dr(2) = i.descripcion
            dr(3) = i.cantidadMinima.GetValueOrDefault
            dr(4) = i.cantidad
            dr(5) = i.unidadMedida
            dr(6) = strGravado
            dr(7) = i.tipoExistencia
            dt.Rows.Add(dr)
        Next
        setDataSourceV2(dt)

        ''dgvKardexVal.DataSource = dt
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '''''ComboStatus()
    End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            sfDataGrid.DataSource = table
            PictureLoad.Visible = False
            BunifuFlatButton4.Enabled = True
            Me.sfDataGrid.ShowBusyIndicator = False

            Dim minCantidad = listaInventario.Max(Function(o) o.cantidadMinima)
            minCantidad = minCantidad + 5

            Dim minCantidadRequerimiento = listaInventario.Max(Function(o) o.cantidadMinima)
            minCantidadRequerimiento = minCantidadRequerimiento - 5

            Dim SinStock As Decimal = listaInventario.Where(Function(o) o.cantidad <= 0).Count
            Dim stockRequeri As Decimal = listaInventario.Where(Function(o) o.cantidad < o.cantidadMinima And o.cantidad > 0).Count
            Dim stockMinimo As Decimal = listaInventario.Where(Function(o) o.cantidad = o.cantidadMinima).Count
            Dim stockBase As Decimal = listaInventario.Where(Function(o) o.cantidad > o.cantidadMinima AndAlso o.cantidad <= minCantidad).Count

            Label2.Text = SinStock
            Label5.Text = stockRequeri
            Label6.Text = stockMinimo
            Label7.Text = stockBase


            'Dim conditionalDescriptor As New GridConditionalFormatDescriptor()

            'object for data bar rule
            'Dim conditionDataBarRule1 As New ConditionalFormatDataBarRule()

            ''Assigning column for data bar
            'conditionDataBarRule1.ColumnName = "Profit"

            ''Adding the rule to rules collection
            'conditionalDescriptor.Rules.Add(conditionDataBarRule1)

            ''Adding descriptor.
            'Me.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(conditionalDescriptor)

        End If
    End Sub

    Private Sub setDataSourceV2(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            sfDataGrid.DataSource = table
            PictureLoad.Visible = False
            BunifuFlatButton4.Enabled = True
            Me.sfDataGrid.ShowBusyIndicator = False


            'Dim conditionalDescriptor As New GridConditionalFormatDescriptor()

            'object for data bar rule
            'Dim conditionDataBarRule1 As New ConditionalFormatDataBarRule()

            ''Assigning column for data bar
            'conditionDataBarRule1.ColumnName = "Profit"

            ''Adding the rule to rules collection
            'conditionalDescriptor.Rules.Add(conditionDataBarRule1)

            ''Adding descriptor.
            'Me.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(conditionalDescriptor)

        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            Dim tipoExistencia = cboTipoExistencia.SelectedValue
            If IsNumeric(codAlmacen) Then
                ' PictureLoad.Visible = True
                BunifuFlatButton4.Enabled = False
                Me.sfDataGrid.ShowBusyIndicator = True
                'Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventario(New totalesAlmacen With {.idAlmacen = codAlmacen, .tipoExistencia = tipoExistencia, .InvAcumulado = True})))
                'thread.Start()

                GetInventario2(New totalesAlmacen With {.idAlmacen = codAlmacen, .tipoExistencia = tipoExistencia, .InvAcumulado = True})
            End If
        End If
    End Sub

    Private Sub GetConsultaGuiada(lista As List(Of totalesAlmacen))
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            Dim tipoExistencia = cboTipoExistencia.SelectedValue
            If IsNumeric(codAlmacen) Then
                PictureLoad.Visible = True
                BunifuFlatButton4.Enabled = False
                Me.sfDataGrid.ShowBusyIndicator = True
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioGuia(lista)))
                thread.Start()
            End If
        End If
    End Sub

    Private Sub sfDataGrid_Click(sender As Object, e As EventArgs) Handles sfDataGrid.Click

    End Sub



#End Region

#Region "Events"
    Private Sub sfDataGrid_QueryCellStyle(sender As Object, e As QueryCellStyleEventArgs) Handles sfDataGrid.QueryCellStyle
        ' If e.DataRow IsNot Nothing Then



        Dim dataRowView = TryCast(e.DataRow.RowData, DataRowView)

        If dataRowView IsNot Nothing Then
            Dim dataRow = dataRowView.Row

            Dim Sinstock As Decimal = 0

            Dim stock As Decimal? = Decimal.Parse(dataRow("stock").ToString())

            Dim requerimiento As Decimal? = Decimal.Parse(dataRow("stockminimo").ToString())
            requerimiento = requerimiento - 5

            Dim valueMinimo As Decimal? = Decimal.Parse(dataRow("stockminimo").ToString())
            Dim ApuntoMinimo As Decimal? = Decimal.Parse(dataRow("stockminimo").ToString())
            ApuntoMinimo = ApuntoMinimo + 5



            'If cellValue = "UK" Then
            '        e.Style.BackColor = Color.PaleTurquoise
            '    ElseIf cellValue = "US" Then
            '        e.Style.BackColor = Color.CornflowerBlue
            '    Else
            '        e.Style.BackColor = Color.Wheat
            '    End If
            'End If
            If stock = 0 And e.ColumnIndex = 4 Then
                e.Style.BackColor = Color.Red
                e.Style.TextColor = Color.White
            ElseIf stock.GetValueOrDefault >= requerimiento.GetValueOrDefault And stock <= (valueMinimo - 0.001) And e.ColumnIndex = 4 Then
                e.Style.BackColor = Color.FromArgb(255, 128, 0)
                e.Style.TextColor = Color.White
            ElseIf stock = valueMinimo And e.ColumnIndex = 4 Then
                e.Style.BackColor = Color.Gold
                e.Style.TextColor = Color.Black
            ElseIf stock > valueMinimo AndAlso stock <= ApuntoMinimo AndAlso e.ColumnIndex = 4 Then
                e.Style.BackColor = Color.FromArgb(252, 94, 212)
                e.Style.TextColor = Color.White
            ElseIf stock <= requerimiento AndAlso stock > 0 AndAlso e.ColumnIndex = 4 Then
                e.Style.BackColor = Color.FromArgb(255, 128, 0)
                e.Style.TextColor = Color.White
            End If


        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If listaInventario IsNot Nothing Then
            Dim lista = listaInventario.Where(Function(o) o.cantidad <= 0).ToList
            GetConsultaGuiada(lista)
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If listaInventario IsNot Nothing Then
            Dim lista = listaInventario.Where(Function(o) o.cantidad < o.cantidadMinima And o.cantidad > 0).ToList
            GetConsultaGuiada(lista)
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If listaInventario IsNot Nothing Then
            Dim lista = listaInventario.Where(Function(o) o.cantidad = o.cantidadMinima).ToList
            GetConsultaGuiada(lista)
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        If listaInventario IsNot Nothing Then
            Dim minCantidad = listaInventario.Max(Function(o) o.cantidadMinima)
            minCantidad = minCantidad + 5
            Dim lista = listaInventario.Where(Function(o) o.cantidad > o.cantidadMinima AndAlso o.cantidad <= minCantidad).ToList
            GetConsultaGuiada(lista)
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If sfDataGrid.SelectedItems IsNot Nothing And sfDataGrid.SelectedItems.Count > 0 Then
            If Syncfusion.Windows.Forms.MessageBoxAdv.Show("Dar de baja producto?", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarEstado("I")
            End If
        End If
    End Sub

    Private Sub CambiarEstado(estado As String)
        Dim itemSA As New detalleitemsSA
        Dim selectedItem = sfDataGrid.SelectedItems(0)
        Dim dataRow = (TryCast(selectedItem, DataRowView)).Row
        Dim cellValue = dataRow("ID").ToString()

        itemSA.CambiarEstadoItem(New detalleitems With
                                 {
                                 .codigodetalle = cellValue,
                                 .estado = estado
                                 })

        sfDataGrid.DeleteSelectedRecords()
        MessageBox.Show("Producto en baja.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region
End Class
