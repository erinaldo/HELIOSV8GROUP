<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaestroCuentas
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridStyleInfo1 As Syncfusion.Windows.Forms.Grid.GridStyleInfo = New Syncfusion.Windows.Forms.Grid.GridStyleInfo()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim HeaderCollection1 As Syncfusion.Windows.Forms.Tools.TreeNavigator.HeaderCollection = New Syncfusion.Windows.Forms.Tools.TreeNavigator.HeaderCollection()
        Me.panel7 = New System.Windows.Forms.Panel()
        Me.label2 = New System.Windows.Forms.Label()
        Me.panel6 = New System.Windows.Forms.Panel()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.GridDataBoundGrid()
        Me.parametro = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.cuentaBase = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.cuentaEspecifica = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.tipoAsiento = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.TabPageAdv2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.dgvItems = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.treeNavigator1 = New Syncfusion.Windows.Forms.Tools.TreeNavigator()
        Me.TreeMenuItem1 = New Syncfusion.Windows.Forms.Tools.TreeMenuItem()
        Me.TreeMenuItem2 = New Syncfusion.Windows.Forms.Tools.TreeMenuItem()
        Me.TreeMenuItem3 = New Syncfusion.Windows.Forms.Tools.TreeMenuItem()
        Me.TreeMenuItem4 = New Syncfusion.Windows.Forms.Tools.TreeMenuItem()
        Me.panel7.SuspendLayout()
        Me.panel6.SuspendLayout()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageAdv2.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel7
        '
        Me.panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel7.Controls.Add(Me.label2)
        Me.panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel7.Location = New System.Drawing.Point(0, 0)
        Me.panel7.Name = "panel7"
        Me.panel7.Size = New System.Drawing.Size(869, 50)
        Me.panel7.TabIndex = 9
        '
        'label2
        '
        Me.label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.SystemColors.Control
        Me.label2.Location = New System.Drawing.Point(3, 14)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(189, 20)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Maestro asientos contables"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panel6
        '
        Me.panel6.Controls.Add(Me.TabControlAdv1)
        Me.panel6.Controls.Add(Me.treeNavigator1)
        Me.panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel6.Location = New System.Drawing.Point(0, 50)
        Me.panel6.Name = "panel6"
        Me.panel6.Size = New System.Drawing.Size(869, 420)
        Me.panel6.TabIndex = 10
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(600, 420)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv2)
        Me.TabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.Location = New System.Drawing.Point(269, 0)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.Size = New System.Drawing.Size(600, 420)
        Me.TabControlAdv1.TabIndex = 6
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererMetro)
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.dgvCuentas)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(597, 396)
        Me.TabPageAdv1.TabIndex = 1
        Me.TabPageAdv1.Text = "Compra"
        Me.TabPageAdv1.ThemesEnabled = False
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AllowDragSelectedCols = True
        Me.dgvCuentas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        GridBaseStyle1.Name = "Column Header"
        GridBaseStyle1.StyleInfo.BaseStyle = "Header"
        GridBaseStyle1.StyleInfo.CellType = "ColumnHeaderCell"
        GridBaseStyle1.StyleInfo.Enabled = False
        GridBaseStyle1.StyleInfo.Font.Bold = True
        GridBaseStyle1.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridBaseStyle2.Name = "Header"
        GridBaseStyle2.StyleInfo.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Left = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.CellType = "Header"
        GridBaseStyle2.StyleInfo.Font.Bold = True
        GridBaseStyle2.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
        GridBaseStyle2.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridBaseStyle3.Name = "Standard"
        GridBaseStyle3.StyleInfo.CheckBoxOptions.CheckedValue = "True"
        GridBaseStyle3.StyleInfo.CheckBoxOptions.UncheckedValue = "False"
        GridBaseStyle3.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridBaseStyle4.Name = "Row Header"
        GridBaseStyle4.StyleInfo.BaseStyle = "Header"
        GridBaseStyle4.StyleInfo.CellType = "RowHeaderCell"
        GridBaseStyle4.StyleInfo.Enabled = True
        GridBaseStyle4.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        Me.dgvCuentas.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
        Me.dgvCuentas.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Blue
        Me.dgvCuentas.DefaultRowHeight = 20
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.EnableAddNew = False
        Me.dgvCuentas.EnableEdit = False
        Me.dgvCuentas.EnableRemove = False
        Me.dgvCuentas.GridBoundColumns.AddRange(New Syncfusion.Windows.Forms.Grid.GridBoundColumn() {Me.parametro, Me.cuentaBase, Me.cuentaEspecifica, Me.tipoAsiento})
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        '    Me.dgvCuentas.IsSpreadsheetFillSeries = False
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.MetroScrollBars = True
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.OptimizeInsertRemoveCells = True
        Me.dgvCuentas.Properties.ForceImmediateRepaint = False
        Me.dgvCuentas.Properties.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.dgvCuentas.Properties.MarkColHeader = False
        Me.dgvCuentas.Properties.MarkRowHeader = False
        Me.dgvCuentas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCuentas.Size = New System.Drawing.Size(597, 396)
        Me.dgvCuentas.SmartSizeBox = False
        Me.dgvCuentas.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.DoubleClick
        'Me.dgvCuentas.SpreadsheetLikeSelection = False
        Me.dgvCuentas.TabIndex = 9
        GridStyleInfo1.BaseStyle = "Standard"
        Me.dgvCuentas.TableStyle = GridStyleInfo1
        Me.dgvCuentas.Text = "GridDataBoundGrid1"
        Me.dgvCuentas.ThemesEnabled = True
        Me.dgvCuentas.TransparentBackground = True
        Me.dgvCuentas.UseListChangedEvent = True
        Me.dgvCuentas.UseRightToLeftCompatibleTextBox = True
        '
        'parametro
        '
        Me.parametro.HeaderText = "T. existencia"
        Me.parametro.Hidden = False
        Me.parametro.MappingName = "parametro"
        Me.parametro.Position = 1
        Me.parametro.ReadOnly = True
        Me.parametro.Width = 50
        '
        'cuentaBase
        '
        Me.cuentaBase.HeaderText = "Generica"
        Me.cuentaBase.Hidden = False
        Me.cuentaBase.MappingName = "cuentaBase"
        Me.cuentaBase.Position = 2
        Me.cuentaBase.ReadOnly = True
        Me.cuentaBase.Width = 80
        '
        'cuentaEspecifica
        '
        Me.cuentaEspecifica.HeaderText = "Especifica"
        Me.cuentaEspecifica.Hidden = False
        Me.cuentaEspecifica.MappingName = "cuentaEspecifica"
        Me.cuentaEspecifica.Position = 3
        Me.cuentaEspecifica.ReadOnly = True
        Me.cuentaEspecifica.Width = 150
        '
        'tipoAsiento
        '
        Me.tipoAsiento.HeaderText = "Asiento"
        Me.tipoAsiento.Hidden = False
        Me.tipoAsiento.MappingName = "tipoAsiento"
        Me.tipoAsiento.Position = 4
        Me.tipoAsiento.ReadOnly = True
        Me.tipoAsiento.Width = 60
        '
        'TabPageAdv2
        '
        Me.TabPageAdv2.Controls.Add(Me.dgvItems)
        Me.TabPageAdv2.Image = Nothing
        Me.TabPageAdv2.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv2.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv2.Name = "TabPageAdv2"
        Me.TabPageAdv2.ShowCloseButton = True
        Me.TabPageAdv2.Size = New System.Drawing.Size(597, 396)
        Me.TabPageAdv2.TabIndex = 2
        Me.TabPageAdv2.Text = "TabPageAdv2"
        Me.TabPageAdv2.ThemesEnabled = False
        '
        'dgvItems
        '
        Me.dgvItems.BackColor = System.Drawing.SystemColors.Window
        Me.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItems.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItems.FreezeCaption = False
        Me.dgvItems.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvItems.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.Size = New System.Drawing.Size(597, 396)
        Me.dgvItems.TabIndex = 11
        Me.dgvItems.TableDescriptor.AllowNew = False
        Me.dgvItems.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvItems.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvItems.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvItems.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvItems.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvItems.TableDescriptor.Appearance.AnyGroupCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvItems.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvItems.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvItems.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvItems.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvItems.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvItems.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvItems.TableDescriptor.Appearance.GroupCaptionCell.CellType = "ColumnHeader"
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "codigodetalle"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 50
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "cuenta"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 80
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "descripcionItem"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 300
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "idItem"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 50
        Me.dgvItems.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
        Me.dgvItems.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvItems.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvItems.TableOptions.AllowDragColumns = False
        Me.dgvItems.Text = "gridGroupingControl1"
        Me.dgvItems.VersionInfo = "6.102.0.34"
        '
        'treeNavigator1
        '
        Me.treeNavigator1.BackColor = System.Drawing.Color.White
        Me.treeNavigator1.Dock = System.Windows.Forms.DockStyle.Left
        Me.treeNavigator1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HeaderCollection1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HeaderCollection1.HeaderText = "EnterpriseToolKit"
        Me.treeNavigator1.Header = HeaderCollection1
        Me.treeNavigator1.ItemBackColor = System.Drawing.SystemColors.Control
        Me.treeNavigator1.Items.Add(Me.TreeMenuItem1)
        Me.treeNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.treeNavigator1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.treeNavigator1.Name = "treeNavigator1"
        Me.treeNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.treeNavigator1.Size = New System.Drawing.Size(269, 420)
        Me.treeNavigator1.TabIndex = 5
        Me.treeNavigator1.Text = "treeNavigator1"
        '
        'TreeMenuItem1
        '
        Me.TreeMenuItem1.BackColor = System.Drawing.SystemColors.Control
        Me.TreeMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.TreeMenuItem1.ItemBackColor = System.Drawing.SystemColors.Control
        Me.TreeMenuItem1.Items.Add(Me.TreeMenuItem2)
        Me.TreeMenuItem1.Items.Add(Me.TreeMenuItem3)
        Me.TreeMenuItem1.Items.Add(Me.TreeMenuItem4)
        Me.TreeMenuItem1.Location = New System.Drawing.Point(2, 0)
        Me.TreeMenuItem1.Name = "TreeMenuItem1"
        Me.TreeMenuItem1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TreeMenuItem1.Size = New System.Drawing.Size(247, 50)
        Me.TreeMenuItem1.TabIndex = 0
        Me.TreeMenuItem1.Text = "Logistica"
        '
        'TreeMenuItem2
        '
        Me.TreeMenuItem2.ItemBackColor = System.Drawing.SystemColors.Control
        Me.TreeMenuItem2.Location = New System.Drawing.Point(0, 0)
        Me.TreeMenuItem2.Name = "TreeMenuItem2"
        Me.TreeMenuItem2.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TreeMenuItem2.Size = New System.Drawing.Size(0, 0)
        Me.TreeMenuItem2.TabIndex = 0
        Me.TreeMenuItem2.Text = "Compra al credito"
        '
        'TreeMenuItem3
        '
        Me.TreeMenuItem3.ItemBackColor = System.Drawing.SystemColors.Control
        Me.TreeMenuItem3.Location = New System.Drawing.Point(0, 0)
        Me.TreeMenuItem3.Name = "TreeMenuItem3"
        Me.TreeMenuItem3.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TreeMenuItem3.Size = New System.Drawing.Size(0, 0)
        Me.TreeMenuItem3.TabIndex = 0
        Me.TreeMenuItem3.Text = "Compra directa sin recepción"
        '
        'TreeMenuItem4
        '
        Me.TreeMenuItem4.ItemBackColor = System.Drawing.SystemColors.Control
        Me.TreeMenuItem4.Location = New System.Drawing.Point(0, 0)
        Me.TreeMenuItem4.Name = "TreeMenuItem4"
        Me.TreeMenuItem4.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TreeMenuItem4.Size = New System.Drawing.Size(0, 0)
        Me.TreeMenuItem4.TabIndex = 0
        Me.TreeMenuItem4.Text = "Compra directa con recepción"
        '
        'frmMaestroCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 470)
        Me.Controls.Add(Me.panel6)
        Me.Controls.Add(Me.panel7)
        Me.Name = "frmMaestroCuentas"
        Me.Text = "Cuentas"
        Me.panel7.ResumeLayout(False)
        Me.panel7.PerformLayout()
        Me.panel6.ResumeLayout(False)
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageAdv2.ResumeLayout(False)
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel7 As System.Windows.Forms.Panel
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents panel6 As System.Windows.Forms.Panel
    Private WithEvents treeNavigator1 As Syncfusion.Windows.Forms.Tools.TreeNavigator
    Friend WithEvents TreeMenuItem1 As Syncfusion.Windows.Forms.Tools.TreeMenuItem
    Friend WithEvents TreeMenuItem2 As Syncfusion.Windows.Forms.Tools.TreeMenuItem
    Friend WithEvents TreeMenuItem3 As Syncfusion.Windows.Forms.Tools.TreeMenuItem
    Friend WithEvents TreeMenuItem4 As Syncfusion.Windows.Forms.Tools.TreeMenuItem
    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents TabPageAdv2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents dgvCuentas As Syncfusion.Windows.Forms.Grid.GridDataBoundGrid
    Friend WithEvents cuentaBase As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents cuentaEspecifica As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents tipoAsiento As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents parametro As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Private WithEvents dgvItems As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
