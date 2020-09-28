Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing

Public Class frmCentralCompras
    Inherits frmMaster

#Region "Métodos"
    Dim colorx As GridMetroColors
    Sub GridCFG()
        Me.gridGroupingControl1.TableOptions.ShowRowHeader = False
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        Me.gridGroupingControl1.SetMetroStyle(colorx)
        Me.gridGroupingControl1.BorderStyle = System.Windows.Forms.BorderStyle.None

        Me.gridGroupingControl1.BrowseOnly = True
        Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Me.gridGroupingControl1.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        Me.gridGroupingControl1.AllowProportionalColumnSizing = False
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        Me.gridGroupingControl1.Table.DefaultColumnHeaderRowHeight = 25
        Me.gridGroupingControl1.Table.DefaultRecordRowHeight = 20
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub LoadMesesCBO()
        Me.comboBox1.ListBox.DrawMode = DrawMode.OwnerDrawVariable

        Dim months As New List(Of String)()
        months.Add("All")
        months.Add("Enero")
        months.Add("Febrero")
        months.Add("Marzo")
        months.Add("Abril")
        months.Add("Mayo")
        months.Add("Junio")
        months.Add("Julio")
        months.Add("Agosto")
        months.Add("Setiembre")
        months.Add("Octubre")
        months.Add("Noviembre")
        months.Add("Diciembre")

        Me.comboBox1.Width = 150
        Me.comboBox1.DataSource = months
    End Sub
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel
    Private Sub ConfiguracionInicio()
        Me.RibbonControlAdv1.QuickPanelVisible = True
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel.Text = "Período:"
        Me.lblPeriodoLabel.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodoLabel.Enabled = False

        ' Set the text and DisplayStyle property.
        Me.lblPeriodo.Text = AnioGeneral
        Me.lblPeriodo.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodo.Enabled = False
        Me.lblPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        '  Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Nodes
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

    Private Sub getTableComprasPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras - período ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasPorPeriodoGeneralCentral(intIdEstablecimiento, strPeriodo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.NombreEntidad
            dr(7) = i.importeTotal
            dr(8) = i.tcDolLoc
            dr(9) = i.importeUS
            dt.Rows.Add(dr)
        Next
        gridGroupingControl1.DataSource = dt
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableComprasPorANio(intIdEstablecimiento As Integer, strANio As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras - período ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasPorANioGeNeral(intIdEstablecimiento, strANio)


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.NombreEntidad
            dr(7) = i.importeTotal
            dr(8) = i.tcDolLoc
            dr(9) = i.importeUS
            dt.Rows.Add(dr)
        Next
        gridGroupingControl1.DataSource = dt
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GridCFG()
        LoadMesesCBO()
        ConfiguracionInicio()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub InitializeChart()
        ' Initialize ChartSeries
        Dim series1 As New ChartSeries("Compras x mes")

        Dim documentoCompraSA As New DocumentoCompraSA
        Dim lista As New List(Of documentocompra)

        lista = documentoCompraSA.GetListarComprasPorAnio(GEstableciento.IdEstablecimiento, AnioGeneral)

        For Each i In lista
            Dim s = CDate(1 & "/" & i.fechaContable)
            series1.Points.Add(CDate(s).Month, i.CountCompras)
            'series1.Points.Add(2, 151)
            'series1.Points.Add(3, 180)
            'series1.Points.Add(4, 206)
            'series1.Points.Add(5, 122)
            'series1.Points.Add(6, 31)
            'series1.Points.Add(7, 189)
            'series1.Points.Add(8, 54)
            'series1.Points.Add(9, 181)
            'series1.Points.Add(10, 201)
            'series1.Points.Add(11, 391)
            'series1.Points.Add(12, 311)
        Next


      

        'series1.Styles[0].Text = string.Format("{0}", series1.Points[0].YValues[0]);
        'series1.Styles[1].Text = string.Format("{0}", series1.Points[1].YValues[0]);
        'series1.Styles[2].Text = string.Format("{0}", series1.Points[2].YValues[0]);
        'series1.Styles[3].Text = string.Format("{0}", series1.Points[3].YValues[0]);
        'series1.Styles[4].Text = string.Format("{0}", series1.Points[4].YValues[0]);


        Me.chartControl1.Series.Add(series1)

        'ChartSeries series2 = new ChartSeries("Monitor");
        'series2.Points.Add(1, 256);
        'series2.Points.Add(2, 451);
        'series2.Points.Add(3, 382);
        'series2.Points.Add(4, 437);
        'series2.Points.Add(5, 321);
        'series2.Points.Add(6, 234);
        'series2.Points.Add(7, 425);
        'series2.Points.Add(8, 257);
        'series2.Points.Add(9, 382);
        'series2.Points.Add(10, 301);
        'series2.Points.Add(11, 472);
        'series2.Points.Add(12, 421);

        'series2.Styles[0].Text = string.Format("{0}", series1.Points[0].YValues[0]);
        'series2.Styles[1].Text = string.Format("{0}", series1.Points[1].YValues[0]);
        'series2.Styles[2].Text = string.Format("{0}", series1.Points[2].YValues[0]);
        'series2.Styles[3].Text = string.Format("{0}", series1.Points[3].YValues[0]);
        'series2.Styles[4].Text = string.Format("{0}", series1.Points[4].YValues[0]);


        'this.chartControl1.Series.Add(series2);

        chartControl1.ColumnDrawMode = ChartColumnDrawMode.ClusteredMode
        'chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.[Set]
        chartControl1.PrimaryXAxis.Range = New MinMaxInfo(0, 13, 1)
        'ChartTemplate ct = new ChartTemplate(typeof(ChartControl));
        'ct.Load("Column_Square.xml");
        'ct.Apply(this.chartControl1);
        chartControl1.Series3D = False
    End Sub

    Private Sub frmCentralCompras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCentralCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeChart()

        ChartAppearance.ApplyChartStyles(Me.chartControl1)
        ' Me.chartControl1.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

    End Sub

    Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        '   Dim filter1 As New RecordFilterDescriptor()
        If Not IsNothing(comboBox1.SelectedValue) Then


            If Me.comboBox1.SelectedValue.Equals("All") Then
                Me.gridGroupingControl1.TableDescriptor.RecordFilters.Clear()
                getTableComprasPorANio(GEstableciento.IdEstablecimiento, AnioGeneral)
            Else
                Select Case comboBox1.SelectedValue
                    Case "Enero"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "01" & "/" & AnioGeneral)
                    Case "Febrero"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "02" & "/" & AnioGeneral)
                    Case "Marzo"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "03" & "/" & AnioGeneral)
                    Case "Abril"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "04" & "/" & AnioGeneral)
                    Case "Mayo"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "05" & "/" & AnioGeneral)
                    Case "Junio"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "06" & "/" & AnioGeneral)
                    Case "Julio"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "07" & "/" & AnioGeneral)
                    Case "Agosto"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "08" & "/" & AnioGeneral)
                    Case "Setiembre"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "09" & "/" & AnioGeneral)
                    Case "Octubre"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "10" & "/" & AnioGeneral)
                    Case "Noviembre"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "11" & "/" & AnioGeneral)
                    Case "Diciembre"
                        getTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, "12" & "/" & AnioGeneral)
                End Select

            End If
        End If
        Me.Cursor = Cursors.Arrow
        'If Not drillDown Then
        '    InitializeChart()
        'Else
        '    InitializeDrillDownChart(currentDrilldownIndex)
        'End If
        'Dim expensedata As New ProcessedExpenseData(Me.comboBox1.SelectedValue.ToString())
        'Me.label1.Text = "$" + expensedata.PositiveAmount.ToString()
        'Me.label2.Text = "Positive" & vbLf
        'Me.label4.Text = "$" + expensedata.NegativeAmount.ToString()
        'Me.label5.Text = "Negative" & vbLf
        'Me.label7.Text = "$" + expensedata.BalanceAmount.ToString()
        'Me.label8.Text = "Balance"
        'Me.label3.Text = expensedata.NoPositiveTransactions + " Transactions"
        'Me.label6.Text = expensedata.NoNegativeTransactions + " Transactions"
        'Me.labelchartlegend1.Text = vbLf & "  Most Spent"
        'Me.labelchartlegend3.Text = " " & vbLf & "  Least Spent"
        'Me.labelchartlegend5.Text = vbLf & "  Average Spent"
        'Me.labelchartlegend2.Text = vbLf & " " + expensedata.MostSpent
        'Me.labelchartlegend4.Text = vbLf & " " + expensedata.LeastSpent
        'Me.labelchartlegend6.Text = vbLf & " " + expensedata.AverageSpent
    End Sub

    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()

    Private Sub gridGroupingControl1_MouseLeave(sender As Object, e As EventArgs) Handles gridGroupingControl1.MouseLeave

        'If selectionColl IsNot Nothing Then
        '    selectionColl.Clear()
        '    Me.gridGroupingControl1.TableControl.Refresh()
        'End If
    End Sub
    Private Sub gridGroupingControl1_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles gridGroupingControl1.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.gridGroupingControl1.TableControl.Selections.Clear()
        End If
    End Sub
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = Me.gridGroupingControl1.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            Me.gridGroupingControl1.TableControl.Refresh()
        End If

        Me.gridGroupingControl1.TableControl.Selections.Clear()

    End Sub

    Private Sub gridGroupingControl1_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHoverEnter
        'Me.labelrecord.Text = "Record " + (e.Inner.RowIndex - 1) + " of " + (Me.gridGroupingControl1.TableModel.RowCount - 1)
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True)
    End Sub
    Private Sub gridGroupingControl1_TableControlCellMouseHoverLeave(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHoverLeave
        ' IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, False)
    End Sub

    Private Sub pictureBoxgrid_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureBoxgrid.MouseClick
        panelgrid.Visible = True
        panelchart.Visible = False
    End Sub

    Private Sub pictureBoxchart_Click(sender As Object, e As EventArgs) Handles pictureBoxchart.Click

    End Sub

    Private Sub pictureBoxchart_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureBoxchart.MouseClick
        panelgrid.Visible = False
        panelchart.Visible = True
    End Sub

    Private Sub chartcontrol1_ChartFormatAxisLabel(sender As Object, e As ChartFormatAxisLabelEventArgs)
        'If e.AxisOrientation = ChartOrientation.Horizontal Then
        '    If e.Value = 1 Then
        '        e.Label = "Science Fiction"
        '    ElseIf e.Value = 2 Then
        '        e.Label = "Mystery"
        '    ElseIf e.Value = 3 Then
        '        e.Label = "Geology"
        '    ElseIf e.Value = 4 Then
        '        e.Label = "History"
        '    ElseIf e.Value = 5 Then
        '        e.Label = "Travel"
        '    ElseIf e.Value = 6 Then
        '        e.Label = "Gardening"
        '    ElseIf e.Value = 7 Then
        '        e.Label = "Computers"
        '    ElseIf e.Value = 8 Then
        '        e.Label = "Computers 4"
        '    ElseIf e.Value = 9 Then
        '        e.Label = "Computers 5"
        '    Else
        '        e.Label = ""
        '    End If

        '    e.Handled = True
        'End If

    End Sub

    Private Sub chartcontrol1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chartControl1_ChartFormatAxisLabel_1(sender As Object, e As ChartFormatAxisLabelEventArgs) Handles chartControl1.ChartFormatAxisLabel
        If e.AxisOrientation = ChartOrientation.Horizontal Then
            If e.Value = 1 Then
                e.Label = "Ene"
            ElseIf e.Value = 2 Then
                e.Label = "Feb"
            ElseIf e.Value = 3 Then
                e.Label = "Mar"
            ElseIf e.Value = 4 Then
                e.Label = "Abr"
            ElseIf e.Value = 5 Then
                e.Label = "May"
            ElseIf e.Value = 6 Then
                e.Label = "Jun"
            ElseIf e.Value = 7 Then
                e.Label = "Jul"
            ElseIf e.Value = 8 Then
                e.Label = "Ago"
            ElseIf e.Value = 9 Then
                e.Label = "Set"
            ElseIf e.Value = 10 Then
                e.Label = "Oct"
            ElseIf e.Value = 11 Then
                e.Label = "Nov"
            ElseIf e.Value = 12 Then
                e.Label = "Dic"
            Else
                e.Label = ""
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub comboBox1_Click(sender As Object, e As EventArgs) Handles comboBox1.Click

    End Sub
End Class