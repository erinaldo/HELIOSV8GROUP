Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Public Class UCInventario

#Region "Attributes"
    Public Property almacenSA As New almacenSA
    Public Property TotalesAlmacenSA As New TotalesAlmacenSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Dim conditionDataBarRule1 As Syncfusion.Windows.Forms.Grid.Grouping.ConditionalFormatDataBarRule = New Syncfusion.Windows.Forms.Grid.Grouping.ConditionalFormatDataBarRule()
    Dim gridConditionalFormatDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvKardexVal, False, False, 8.0F)
        'FormatoGridBlack(dgvKardexVal, False)
        OrdenamientoGrid(dgvKardexVal, False)
        LoadCombos()

        Me.dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyRecordFieldCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Me.dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyRecordFieldCell.WrapText = False
        Me.dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyRecordFieldCell.Trimming = StringTrimming.EllipsisCharacter

        Me.dgvKardexVal.TableControl.CellToolTip.AutomaticDelay = 25000
    End Sub
#End Region

#Region "Databar"
    Private Sub GetDatabar()
        gridConditionalFormatDescriptor1.Expression = "[cantidad] > '0' AND [cantidad] < '100' "
        gridConditionalFormatDescriptor1.Name = "ConditionalFormat 1"
        conditionDataBarRule1.ColumnName = "cantidad"
        conditionDataBarRule1.AxisPosition = AxisPosition.Automatic
        conditionDataBarRule1.FillNegativeColorSameAsPositive = False
        conditionDataBarRule1.AutoCalculateMinMax = True
        conditionDataBarRule1.PositiveBar.FillStyle = FillStyle.Gradient
        conditionDataBarRule1.PositiveBar.GradientFillColor1 = Color.DeepSkyBlue
        conditionDataBarRule1.PositiveBar.GradientFillColor2 = Color.FromArgb(255, 255, 255)
        conditionDataBarRule1.PositiveBar.BorderColor = conditionDataBarRule1.PositiveBar.GradientFillColor1
        conditionDataBarRule1.NegativeBar.FillStyle = FillStyle.Gradient
        conditionDataBarRule1.NegativeBar.GradientFillColor1 = Color.FromArgb(235, 82, 82)
        conditionDataBarRule1.NegativeBar.GradientFillColor2 = Color.FromArgb(254, 255, 255)
        conditionDataBarRule1.NegativeBar.BorderColor = Color.Red
        conditionDataBarRule1.Name = "ConditionalDataBarRule 1"
        gridConditionalFormatDescriptor1.Rules.Add(conditionDataBarRule1)

        Me.dgvKardexVal.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1)
    End Sub
#End Region

#Region "Methods"
    Private Sub LoadCombos()
        dgvKardexVal.Table.Records.DeleteAll()
        dgvKardexVal.TableDescriptor.Columns("Clasificacion").Width = 0
        dgvKardexVal.TableDescriptor.Columns("NroLote").Width = 0
        dgvKardexVal.TableDescriptor.Columns("fechaLote").Width = 0
        dgvKardexVal.TableDescriptor.Columns("cantmax").Width = 0
        dgvKardexVal.TableDescriptor.Columns("cantmin").Width = 0
        dgvKardexVal.TableDescriptor.Columns("status").Width = 0
        dgvKardexVal.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = GetExistencias()

        Dim be As New almacen
        be.TipoConsulta = "UNIDAD_ORGANICA"
        be.idEmpresa = Gempresas.IdEmpresaRuc
        be.idEstablecimiento = GEstableciento.IdEstablecimiento

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(be)
    End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvKardexVal.DataSource = table
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvKardexVal.TableDescriptor.Columns("cantidad").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvKardexVal.TableDescriptor.Columns("cantidad").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right
            'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.Trimming = StringTrimming.EllipsisWord

            dgvKardexVal.TableDescriptor.Columns("cantidad").Width = 200
            Me.dgvKardexVal.UseRightToLeftCompatibleTextBox = True
            PictureLoad.Visible = False
            BunifuFlatButton4.Enabled = True
            GetDatabar()
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

    Private Sub GetInventario(be As totalesAlmacen)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")
        dt.Columns.Add("fechaLote")
        dt.Columns.Add("NroLote")
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("importeTotal")
        dt.Columns.Add("resumentotalcosto")

        Dim listaInventario As New List(Of totalesAlmacen)

        Select Case ComboParametros.Text
            Case "SOLO ARTICULOS CON STOCK"
                listaInventario = TotalesAlmacenSA.GetInventarioGeneral(be).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
            Case "-TODOS-"
                listaInventario = TotalesAlmacenSA.GetInventarioGeneral(be).OrderBy(Function(o) o.descripcion).ToList
        End Select

        For Each i As totalesAlmacen In listaInventario 'TotalesAlmacenSA.GetInventarioGeneral(be).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
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

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            If i.fechaLote.HasValue Then
                dr(14) = i.fechaLote.Value.ToString("dd-MM-yyyy")
            End If

            dr(15) = i.NroLote
            dr(16) = i.codigoLote

            Dim total = i.importeSoles.GetValueOrDefault * 0.18
            total = FormatNumber(i.importeSoles.GetValueOrDefault + total, 2)
            If (i.origenRecaudo = 1) Then
                dr(17) = total.ToString("N2")
            Else
                dr(17) = "-"
            End If

            If (i.origenRecaudo = 1) Then
                dr(18) = total.ToString("N2")
            Else
                dr(18) = i.importeSoles
            End If

            dt.Rows.Add(dr)
        Next
        setDataSource(dt)

        ''dgvKardexVal.DataSource = dt
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '''''ComboStatus()
    End Sub

    Private Sub GetInventarioValorizadoFiltro(be As totalesAlmacen)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")
        dt.Columns.Add("fechaLote")
        dt.Columns.Add("NroLote")
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("importeTotal")
        dt.Columns.Add("resumentotalcosto")

        For Each i As totalesAlmacen In TotalesAlmacenSA.GetFilterArticulosStartWith(be).OrderBy(Function(o) o.descripcion).ToList

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

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            dr(14) = i.fechaLote
            dr(15) = i.NroLote
            dr(16) = i.codigoLote

            Dim total = i.importeSoles.GetValueOrDefault * 0.18
            total = FormatNumber(i.importeSoles.GetValueOrDefault + total, 2)
            If (i.origenRecaudo = 1) Then
                dr(17) = total.ToString("N2")
            Else
                dr(17) = "-"
            End If

            If (i.origenRecaudo = 1) Then
                dr(18) = total.ToString("N2")
            Else
                dr(18) = i.importeSoles
            End If
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)
        'dgvKardexVal.DataSource = dt
        'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

#End Region

#Region "Events"
    Private Sub ChInventAcum_OnChange(sender As Object, e As EventArgs) Handles ChInventAcum.OnChange
        If ChInventAcum.Checked = True Then
            dgvKardexVal.Table.Records.DeleteAll()
            dgvKardexVal.TableDescriptor.Columns("Clasificacion").Width = 0
            dgvKardexVal.TableDescriptor.Columns("NroLote").Width = 0
            dgvKardexVal.TableDescriptor.Columns("fechaLote").Width = 0
            dgvKardexVal.TableDescriptor.Columns("cantmax").Width = 0
            dgvKardexVal.TableDescriptor.Columns("cantmin").Width = 0
            dgvKardexVal.TableDescriptor.Columns("status").Width = 0
        ElseIf ChInventAcum.Checked = False Then
            dgvKardexVal.Table.Records.DeleteAll()
            dgvKardexVal.TableDescriptor.Columns("Clasificacion").Width = 100
            dgvKardexVal.TableDescriptor.Columns("NroLote").Width = 70
            dgvKardexVal.TableDescriptor.Columns("fechaLote").Width = 120
            dgvKardexVal.TableDescriptor.Columns("cantmax").Width = 70
            dgvKardexVal.TableDescriptor.Columns("cantmin").Width = 70
            dgvKardexVal.TableDescriptor.Columns("status").Width = 0 ' 80
        End If
    End Sub

    Private Sub txtBuscarDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If cboAlmacen.SelectedIndex > -1 Then
                Dim codAlmacen = cboAlmacen.SelectedValue
                If IsNumeric(codAlmacen) Then
                    If txtBuscarDetalle.Text.Trim.Length > 0 Then
                        Dim t As New totalesAlmacen With {.idAlmacen = cboAlmacen.SelectedValue,
                                                          .tipoExistencia = cboTipoExistencia.SelectedValue,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .descripcion = txtBuscarDetalle.Text,
                                                          .InvAcumulado = True,
                                                          .tipoConsulta = "UNIDAD_ORGANICA"}
                        PictureLoad.Visible = True
                        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioValorizadoFiltro(t)))
                        thread.Start()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            Dim tipoExistencia = cboTipoExistencia.SelectedValue
            If IsNumeric(codAlmacen) Then
                PictureLoad.Visible = True
                BunifuFlatButton4.Enabled = False
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventario(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                                                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                                                                         .idAlmacen = codAlmacen, .tipoExistencia = tipoExistencia,
                                                                                                                                         .InvAcumulado = True,
                                                                                                                                         .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})))
                thread.Start()
            End If
        End If
    End Sub

    Private Sub txtBuscarDetalle_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarDetalle.TextChanged

    End Sub

    Private Sub GridCompra_TableControlPrepareViewStyleInfo(sender As Object, e As GridTableControlPrepareViewStyleInfoEventArgs) Handles dgvKardexVal.TableControlPrepareViewStyleInfo
        If e.Inner.RowIndex > 0 AndAlso e.Inner.ColIndex > 0 Then

            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = dgvKardexVal.TableControl.CurrentCell
            'cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then
                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)
                    If style.TableCellIdentity.Column.Name = "descripcion" Then
                        e.Inner.Style.WrapText = False
                        e.Inner.Style.Trimming = StringTrimming.EllipsisCharacter
                        '  e.Inner.Style.CellTipText = e.Inner.Style.Text
                        'Else
                        '    e.Inner.Style.WrapText = False
                        '    e.Inner.Style.Trimming = StringTrimming.EllipsisCharacter
                        'e.Inner.Style.CellTipText = e.Inner.Style.Text
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvKardexVal_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvKardexVal.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "descripcion" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            e.Style.CellTipText = e.Style.Text

            Dim stock As Decimal? = Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cantidad").ToString())

            Dim requerimiento As Decimal? = Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cantmin").ToString())
            requerimiento = requerimiento - 5

            Dim valueMinimo As Decimal? = Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cantmin").ToString())
            Dim ApuntoMinimo As Decimal? = Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cantmin").ToString())
            ApuntoMinimo = ApuntoMinimo + 5


            Dim StockMaximo As Decimal? = Decimal.Parse(e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cantmax").ToString())
            Dim stockMaximoLimite = StockMaximo - 0.001

            If stock = 0 Then
                e.Style.BackColor = Color.Red
                e.Style.TextColor = Color.White
            ElseIf stock.GetValueOrDefault >= requerimiento.GetValueOrDefault And stock <= (valueMinimo - 0.001) Then
                e.Style.BackColor = Color.FromArgb(255, 128, 0)
                e.Style.TextColor = Color.White
            ElseIf stock = valueMinimo Then
                e.Style.BackColor = Color.Gold
                e.Style.TextColor = Color.Black
            ElseIf stock > valueMinimo AndAlso stock <= ApuntoMinimo Then
                e.Style.BackColor = Color.FromArgb(252, 94, 212)
                e.Style.TextColor = Color.White
            ElseIf stock <= requerimiento AndAlso stock > 0 Then
                e.Style.BackColor = Color.FromArgb(255, 128, 0)
                e.Style.TextColor = Color.White
            ElseIf stock > requerimiento AndAlso stock <= stockMaximoLimite Then
                e.Style.BackColor = Color.FromArgb(58, 168, 244)
                e.Style.TextColor = Color.White
            ElseIf stock = StockMaximo Then
                e.Style.BackColor = Color.FromArgb(28, 169, 82)
                e.Style.TextColor = Color.White
            ElseIf stock > StockMaximo Then
                e.Style.BackColor = Color.FromArgb(69, 36, 169)
                e.Style.TextColor = Color.White
            End If

        End If
    End Sub

    Private Sub dgvKardexVal_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardexVal.TableControlCellClick

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

    End Sub

    Private Sub btnImportarExcel_Click(sender As Object, e As EventArgs) Handles btnImportarExcel.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.dgvKardexVal, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Exportar Registro Inventario Valorizado a un archivo excel ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub
#End Region

End Class
