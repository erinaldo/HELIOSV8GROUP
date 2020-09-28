<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCRankingProductos
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
        Me.GridRentabilidad.TabIndex = 719
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "CODIGO"
        GridColumnDescriptor1.MappingName = "Codigo"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "PRODUCTO"
        GridColumnDescriptor2.MappingName = "Producto"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 240
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "AFECTACION"
        GridColumnDescriptor3.MappingName = "Afectacion"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 81
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "TIPO EXIST."
        GridColumnDescriptor4.MappingName = "tipoexistencia"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 98
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "UNIDAD"
        GridColumnDescriptor5.MappingName = "unidad"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 85
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "CANTIDAD"
        GridColumnDescriptor6.MappingName = "cantidad"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 92
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "TOTAL VENTA"
        GridColumnDescriptor7.MappingName = "totalventa"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 116
        Me.GridRentabilidad.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("totalventa", Syncfusion.Grouping.SummaryType.DoubleAggregate, "totalventa", "{Sum}")})
        GridSummaryRowDescriptor1.Title = "Total"
        Me.GridRentabilidad.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.GridRentabilidad.Text = "GridGroupingControl2"
        Me.GridRentabilidad.TopLevelGroupOptions.ShowSummaries = True
        Me.GridRentabilidad.VersionInfo = "12.4400.0.24"
        '
        'UCRankingProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridRentabilidad)
        Me.Name = "UCRankingProductos"
        Me.Size = New System.Drawing.Size(976, 481)
        CType(Me.GridRentabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridRentabilidad As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
