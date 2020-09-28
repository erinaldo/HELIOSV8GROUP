<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabMG_Productos
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabMG_Productos))
        Me.GridProductos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ChFiltro2 = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PonerInactivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccinarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarSelecciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TextBuscarProduct = New System.Windows.Forms.ToolStripTextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridProductos
        '
        Me.GridProductos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.GridProductos.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridProductos.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridProductos.BackColor = System.Drawing.SystemColors.Control
        Me.GridProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProductos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridProductos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridProductos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridProductos.Location = New System.Drawing.Point(0, 29)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridProductos.Size = New System.Drawing.Size(934, 504)
        Me.GridProductos.TabIndex = 301
        Me.GridProductos.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.CheckBoxOptions.IndetermValue = "False"
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info)
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "codigo"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor2.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor2.MappingName = "codigobarra"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 90
        GridColumnDescriptor3.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor3.MappingName = "descripcion"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 220
        GridColumnDescriptor4.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor4.MappingName = "unidad"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 90
        GridColumnDescriptor5.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor5.MappingName = "categoria"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 143
        GridColumnDescriptor6.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor6.MappingName = "tipo"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 112
        GridColumnDescriptor7.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor7.MappingName = "impuesto"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor8.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor8.MappingName = "estado"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor9.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CheckBoxOptions.IndetermValue = "False"
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.InactiveBorder)
        GridColumnDescriptor9.MappingName = "selec"
        GridColumnDescriptor9.Width = 0
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor10.MappingName = "marca"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.Width = 150
        Me.GridProductos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        Me.GridProductos.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridProductos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridProductos.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridProductos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigobarra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("categoria"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("marca"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("impuesto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("selec")})
        Me.GridProductos.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridProductos.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridProductos.Text = "gridGroupingControl1"
        Me.GridProductos.UseRightToLeftCompatibleTextBox = True
        Me.GridProductos.VersionInfo = "12.2400.0.20"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackColor = System.Drawing.Color.White
        Me.GradientPanel8.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.ChFiltro2)
        Me.GradientPanel8.Controls.Add(Me.Label7)
        Me.GradientPanel8.Controls.Add(Me.ToolStrip1)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(934, 29)
        Me.GradientPanel8.TabIndex = 300
        '
        'ChFiltro2
        '
        Me.ChFiltro2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChFiltro2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChFiltro2.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChFiltro2.Checked = True
        Me.ChFiltro2.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChFiltro2.ForeColor = System.Drawing.Color.White
        Me.ChFiltro2.Location = New System.Drawing.Point(811, 4)
        Me.ChFiltro2.Name = "ChFiltro2"
        Me.ChFiltro2.Size = New System.Drawing.Size(20, 20)
        Me.ChFiltro2.TabIndex = 527
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(833, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 526
        Me.Label7.Text = "Por Coincidencia"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripSeparator1, Me.ToolStripLabel4, Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripSeparator2, Me.ToolStripLabel3, Me.ToolStripSeparator3, Me.ToolStripLabel2, Me.TextBuscarProduct, Me.ProgressBar1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(932, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton3.Tag = "Inactivo"
        Me.ToolStripButton3.Text = "Filtros"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        Me.ToolStripSeparator1.Visible = False
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(90, 24)
        Me.ToolStripLabel4.Text = "Listar productos"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(61, 24)
        Me.ToolStripButton2.Text = "Editar"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PonerInactivoToolStripMenuItem, Me.ActivarToolStripMenuItem, Me.SeleccinarTodoToolStripMenuItem, Me.QuitarSelecciónToolStripMenuItem, Me.EliminarProductoToolStripMenuItem})
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(126, 24)
        Me.ToolStripButton4.Text = "Estado producto"
        '
        'PonerInactivoToolStripMenuItem
        '
        Me.PonerInactivoToolStripMenuItem.Image = CType(resources.GetObject("PonerInactivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PonerInactivoToolStripMenuItem.Name = "PonerInactivoToolStripMenuItem"
        Me.PonerInactivoToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.PonerInactivoToolStripMenuItem.Text = "Poner inactivo"
        '
        'ActivarToolStripMenuItem
        '
        Me.ActivarToolStripMenuItem.Image = CType(resources.GetObject("ActivarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ActivarToolStripMenuItem.Name = "ActivarToolStripMenuItem"
        Me.ActivarToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.ActivarToolStripMenuItem.Text = "Activar "
        '
        'SeleccinarTodoToolStripMenuItem
        '
        Me.SeleccinarTodoToolStripMenuItem.Name = "SeleccinarTodoToolStripMenuItem"
        Me.SeleccinarTodoToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.SeleccinarTodoToolStripMenuItem.Text = "Seleccinar todo"
        Me.SeleccinarTodoToolStripMenuItem.Visible = False
        '
        'QuitarSelecciónToolStripMenuItem
        '
        Me.QuitarSelecciónToolStripMenuItem.Name = "QuitarSelecciónToolStripMenuItem"
        Me.QuitarSelecciónToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.QuitarSelecciónToolStripMenuItem.Text = "Quitar selección"
        Me.QuitarSelecciónToolStripMenuItem.Visible = False
        '
        'EliminarProductoToolStripMenuItem
        '
        Me.EliminarProductoToolStripMenuItem.Image = CType(resources.GetObject("EliminarProductoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EliminarProductoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EliminarProductoToolStripMenuItem.Name = "EliminarProductoToolStripMenuItem"
        Me.EliminarProductoToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.EliminarProductoToolStripMenuItem.Text = "Eliminar producto"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripLabel3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripLabel3.Image = CType(resources.GetObject("ToolStripLabel3.Image"), System.Drawing.Image)
        Me.ToolStripLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(106, 24)
        Me.ToolStripLabel3.Text = "Generar aporte"
        Me.ToolStripLabel3.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        Me.ToolStripSeparator3.Visible = False
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(16, 24)
        Me.ToolStripLabel2.Text = "Buscar"
        '
        'TextBuscarProduct
        '
        Me.TextBuscarProduct.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBuscarProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBuscarProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBuscarProduct.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.TextBuscarProduct.Name = "TextBuscarProduct"
        Me.TextBuscarProduct.Size = New System.Drawing.Size(200, 27)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.AutoSize = False
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(60, 10)
        Me.ProgressBar1.Visible = False
        '
        'TabMG_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridProductos)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TabMG_Productos"
        Me.Size = New System.Drawing.Size(934, 533)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        Me.GradientPanel8.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents GridProductos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripDropDownButton
    Friend WithEvents PonerInactivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ProgressBar1 As ToolStripProgressBar
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TextBuscarProduct As ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SeleccinarTodoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitarSelecciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel3 As ToolStripButton
    Friend WithEvents EliminarProductoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChFiltro2 As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
End Class
