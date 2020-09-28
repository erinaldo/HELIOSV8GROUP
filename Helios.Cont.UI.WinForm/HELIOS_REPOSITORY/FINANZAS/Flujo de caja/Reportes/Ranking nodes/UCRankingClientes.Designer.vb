<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCRankingClientes
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Me.GridRentabilidad = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GridRentabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridRentabilidad
        '
        Me.GridRentabilidad.BackColor = System.Drawing.Color.Black
        Me.GridRentabilidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridRentabilidad.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridRentabilidad.FreezeCaption = False
        Me.GridRentabilidad.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.GridRentabilidad.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.GridRentabilidad.Location = New System.Drawing.Point(0, 0)
        Me.GridRentabilidad.Name = "GridRentabilidad"
        Me.GridRentabilidad.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.GridRentabilidad.Size = New System.Drawing.Size(976, 481)
        Me.GridRentabilidad.TabIndex = 718
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "CLIENTE"
        GridColumnDescriptor1.MappingName = "Cliente"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 237
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "DOC. IDENT."
        GridColumnDescriptor2.MappingName = "tipodoc"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 90
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "NRO. DOC."
        GridColumnDescriptor3.MappingName = "nrodoc"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 119
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "TIPO"
        GridColumnDescriptor4.MappingName = "tipo"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 93
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "VENTA SIN IVA"
        GridColumnDescriptor5.MappingName = "ventasiniva"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 106
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "I.V.A."
        GridColumnDescriptor6.MappingName = "iva"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 101
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "VENTA CON IVA."
        GridColumnDescriptor7.MappingName = "ventaconiva"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 126
        Me.GridRentabilidad.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.PositiveColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("ventasiniva", Syncfusion.Grouping.SummaryType.DoubleAggregate, "ventasiniva", "{Sum}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("iva", Syncfusion.Grouping.SummaryType.DoubleAggregate, "iva", "{Sum}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("ventaconiva", Syncfusion.Grouping.SummaryType.DoubleAggregate, "ventaconiva", "{Sum}")})
        GridSummaryRowDescriptor1.Title = "Total"
        Me.GridRentabilidad.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.GridRentabilidad.Text = "GridGroupingControl2"
        Me.GridRentabilidad.TopLevelGroupOptions.ShowSummaries = True
        Me.GridRentabilidad.VersionInfo = "12.4400.0.24"
        '
        'UCRankingClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.GridRentabilidad)
        Me.Name = "UCRankingClientes"
        Me.Size = New System.Drawing.Size(976, 481)
        CType(Me.GridRentabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridRentabilidad As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
