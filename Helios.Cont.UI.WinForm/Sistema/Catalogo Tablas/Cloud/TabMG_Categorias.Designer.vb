<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TabMG_Categorias
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabMG_Categorias))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboCategorias = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PonerInactivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.dgvCompras = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel11.SuspendLayout()
        CType(Me.cboCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.Color.White
        Me.GradientPanel11.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel11.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel11.Controls.Add(Me.cboCategorias)
        Me.GradientPanel11.Controls.Add(Me.Label21)
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(961, 40)
        Me.GradientPanel11.TabIndex = 296
        Me.GradientPanel11.Visible = False
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(83, 25)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(427, 8)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(83, 25)
        Me.ButtonAdv1.TabIndex = 461
        Me.ButtonAdv1.Text = "Consultar"
        Me.ButtonAdv1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'cboCategorias
        '
        Me.cboCategorias.BackColor = System.Drawing.Color.White
        Me.cboCategorias.BeforeTouchSize = New System.Drawing.Size(316, 21)
        Me.cboCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategorias.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategorias.Items.AddRange(New Object() {"PRINCIPAL", "CLASIFICACION", "SUBCLASIFICACION", "MARCA", "MODELO/PRESENTACION"})
        Me.cboCategorias.Location = New System.Drawing.Point(105, 12)
        Me.cboCategorias.Name = "cboCategorias"
        Me.cboCategorias.Size = New System.Drawing.Size(316, 21)
        Me.cboCategorias.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCategorias.TabIndex = 1
        Me.cboCategorias.Text = "PRINCIPAL"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Tipo Clasificacion"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton3, Me.ToolStripSeparator1, Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripSeparator2, Me.ProgressBar1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(961, 27)
        Me.ToolStrip1.TabIndex = 297
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(30, 24)
        Me.ToolStripLabel1.Text = "Lista"
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
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripButton2.Text = "Editar"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PonerInactivoToolStripMenuItem, Me.ActivarToolStripMenuItem})
        Me.ToolStripButton4.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(99, 24)
        Me.ToolStripButton4.Text = "Estado item"
        '
        'PonerInactivoToolStripMenuItem
        '
        Me.PonerInactivoToolStripMenuItem.Image = CType(resources.GetObject("PonerInactivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PonerInactivoToolStripMenuItem.Name = "PonerInactivoToolStripMenuItem"
        Me.PonerInactivoToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PonerInactivoToolStripMenuItem.Text = "Poner inactivo"
        '
        'ActivarToolStripMenuItem
        '
        Me.ActivarToolStripMenuItem.Image = CType(resources.GetObject("ActivarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ActivarToolStripMenuItem.Name = "ActivarToolStripMenuItem"
        Me.ActivarToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ActivarToolStripMenuItem.Text = "Activar "
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.AutoSize = False
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(60, 10)
        Me.ProgressBar1.Visible = False
        '
        'dgvCompras
        '
        Me.dgvCompras.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgvCompras.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompras.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompras.BackColor = System.Drawing.SystemColors.Control
        Me.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCompras.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompras.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCompras.Location = New System.Drawing.Point(0, 67)
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCompras.Size = New System.Drawing.Size(961, 372)
        Me.dgvCompras.TabIndex = 300
        Me.dgvCompras.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "idItem"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.MappingName = "nomPadre"
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.MappingName = "idPadre"
        GridColumnDescriptor3.Width = 0
        GridColumnDescriptor4.HeaderText = "Descripcion"
        GridColumnDescriptor4.MappingName = "descripcion"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 180
        GridColumnDescriptor5.MappingName = "tipo"
        GridColumnDescriptor5.Width = 0
        GridColumnDescriptor6.HeaderText = "Codigo Interno"
        GridColumnDescriptor6.MappingName = "codigo"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 120
        Me.dgvCompras.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6})
        Me.dgvCompras.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.dgvCompras.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompras.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCompras.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nomPadre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idPadre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigo")})
        Me.dgvCompras.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvCompras.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgvCompras.Text = "gridGroupingControl1"
        Me.dgvCompras.UseRightToLeftCompatibleTextBox = True
        Me.dgvCompras.VersionInfo = "12.2400.0.20"
        '
        'TabMG_Categorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvCompras)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Name = "TabMG_Categorias"
        Me.Size = New System.Drawing.Size(961, 439)
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel11.ResumeLayout(False)
        Me.GradientPanel11.PerformLayout()
        CType(Me.cboCategorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboCategorias As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label21 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripDropDownButton
    Friend WithEvents PonerInactivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ProgressBar1 As ToolStripProgressBar
    Private WithEvents dgvCompras As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
