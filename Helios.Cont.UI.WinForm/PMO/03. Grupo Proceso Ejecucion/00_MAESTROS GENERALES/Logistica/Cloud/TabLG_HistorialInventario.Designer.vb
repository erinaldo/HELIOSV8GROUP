<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TabLG_HistorialInventario
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabLG_HistorialInventario))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cboMes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GridInventario = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel11.SuspendLayout()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel11.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel11.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Controls.Add(Me.cboMes)
        Me.GradientPanel11.Controls.Add(Me.Label1)
        Me.GradientPanel11.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel11.Controls.Add(Me.cboAnio)
        Me.GradientPanel11.Controls.Add(Me.Label21)
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(873, 40)
        Me.GradientPanel11.TabIndex = 295
        Me.GradientPanel11.Visible = False
        '
        'cboMes
        '
        Me.cboMes.BackColor = System.Drawing.Color.White
        Me.cboMes.BeforeTouchSize = New System.Drawing.Size(96, 21)
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.Location = New System.Drawing.Point(163, 12)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(96, 21)
        Me.cboMes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMes.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(131, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Mes"
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(86, 25)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(265, 8)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(86, 25)
        Me.ButtonAdv6.TabIndex = 3
        Me.ButtonAdv6.Text = "Consultar"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(75, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(48, 12)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(75, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 14)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Anio"
        '
        'GridInventario
        '
        Me.GridInventario.BackColor = System.Drawing.SystemColors.Window
        Me.GridInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridInventario.FreezeCaption = False
        Me.GridInventario.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridInventario.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridInventario.Location = New System.Drawing.Point(0, 40)
        Me.GridInventario.Name = "GridInventario"
        Me.GridInventario.Size = New System.Drawing.Size(873, 361)
        Me.GridInventario.TabIndex = 297
        Me.GridInventario.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "almacen"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 140
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "producto"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 176
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "lote"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 80
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "unidad"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 90
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "tipoex"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 118
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "cantidad"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 93
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(252, Byte), Integer)))
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "costo"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 123
        Me.GridInventario.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor1.DataMember = "costo"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "costo"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        Me.GridInventario.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.GridInventario.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridInventario.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridInventario.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridInventario.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("almacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("lote"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoex"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("costo")})
        Me.GridInventario.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.GridInventario.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.GridInventario.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.GridInventario.Text = "gridGroupingControl1"
        Me.GridInventario.VersionInfo = "12.2400.0.20"
        '
        'TabLG_HistorialInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridInventario)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TabLG_HistorialInventario"
        Me.Size = New System.Drawing.Size(873, 401)
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel11.ResumeLayout(False)
        Me.GradientPanel11.PerformLayout()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label21 As Label
    Private WithEvents GridInventario As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents cboMes As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
End Class
