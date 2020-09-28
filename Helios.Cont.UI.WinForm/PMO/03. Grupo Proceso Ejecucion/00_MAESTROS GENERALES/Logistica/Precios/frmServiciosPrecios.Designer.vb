<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiciosPrecios
    Inherits frmMaster

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServiciosPrecios))
        Dim GridColumnDescriptor23 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor24 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor25 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor26 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor27 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor28 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor29 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor30 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor31 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor32 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor33 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvServicio = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvPreciosServicio = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPreciosServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(892, 37)
        Me.Panel2.TabIndex = 448
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(103, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "/ Asignar precios"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SERVICIOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvServicio
        '
        Me.dgvServicio.BackColor = System.Drawing.SystemColors.Window
        Me.dgvServicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServicio.FreezeCaption = False
        Me.dgvServicio.Location = New System.Drawing.Point(0, 69)
        Me.dgvServicio.Name = "dgvServicio"
        Me.dgvServicio.Size = New System.Drawing.Size(892, 276)
        Me.dgvServicio.TabIndex = 449
        GridColumnDescriptor23.HeaderImage = Nothing
        GridColumnDescriptor23.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor23.MappingName = "idItem"
        GridColumnDescriptor23.ReadOnly = True
        GridColumnDescriptor23.SerializedImageArray = ""
        GridColumnDescriptor23.Width = 50
        GridColumnDescriptor24.HeaderImage = Nothing
        GridColumnDescriptor24.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor24.MappingName = "descripcion"
        GridColumnDescriptor24.ReadOnly = True
        GridColumnDescriptor24.SerializedImageArray = ""
        GridColumnDescriptor24.Width = 200
        GridColumnDescriptor25.HeaderImage = Nothing
        GridColumnDescriptor25.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor25.MappingName = "cuenta"
        GridColumnDescriptor25.ReadOnly = True
        GridColumnDescriptor25.SerializedImageArray = ""
        GridColumnDescriptor25.Width = 70
        GridColumnDescriptor26.HeaderImage = Nothing
        GridColumnDescriptor26.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor26.MappingName = "observaciones"
        GridColumnDescriptor26.ReadOnly = True
        GridColumnDescriptor26.SerializedImageArray = ""
        GridColumnDescriptor26.Width = 180
        Me.dgvServicio.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor23, GridColumnDescriptor24, GridColumnDescriptor25, GridColumnDescriptor26})
        Me.dgvServicio.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuenta"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("observaciones")})
        Me.dgvServicio.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvServicio.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvServicio.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvServicio.Text = "gridGroupingControl1"
        Me.dgvServicio.VersionInfo = "12.2400.0.20"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 37)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(892, 32)
        Me.ToolStrip1.TabIndex = 451
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(107, 29)
        Me.ToolStripButton1.Text = "Asignar Precio"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(132, 29)
        Me.ToolStripButton2.Text = "Eliminar asignación"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvPreciosServicio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 345)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 141)
        Me.Panel1.TabIndex = 452
        '
        'dgvPreciosServicio
        '
        Me.dgvPreciosServicio.BackColor = System.Drawing.Color.MintCream
        Me.dgvPreciosServicio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPreciosServicio.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvPreciosServicio.FreezeCaption = False
        Me.dgvPreciosServicio.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvPreciosServicio.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Custom
        Me.dgvPreciosServicio.Location = New System.Drawing.Point(0, 0)
        Me.dgvPreciosServicio.Name = "dgvPreciosServicio"
        Me.dgvPreciosServicio.Size = New System.Drawing.Size(736, 141)
        Me.dgvPreciosServicio.TabIndex = 446
        Me.dgvPreciosServicio.TableDescriptor.AllowNew = False
        GridColumnDescriptor27.HeaderImage = Nothing
        GridColumnDescriptor27.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor27.HeaderText = "Fecha"
        GridColumnDescriptor27.MappingName = "fecha"
        GridColumnDescriptor27.ReadOnly = True
        GridColumnDescriptor27.SerializedImageArray = ""
        GridColumnDescriptor27.Width = 180
        GridColumnDescriptor28.HeaderImage = Nothing
        GridColumnDescriptor28.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor28.MappingName = "idPrecio"
        GridColumnDescriptor28.ReadOnly = True
        GridColumnDescriptor28.SerializedImageArray = ""
        GridColumnDescriptor28.Width = 10
        GridColumnDescriptor29.HeaderImage = Nothing
        GridColumnDescriptor29.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor29.MappingName = "Precio"
        GridColumnDescriptor29.ReadOnly = True
        GridColumnDescriptor29.SerializedImageArray = ""
        GridColumnDescriptor29.Width = 200
        GridColumnDescriptor30.HeaderImage = Nothing
        GridColumnDescriptor30.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor30.MappingName = "tipoConfig"
        GridColumnDescriptor30.ReadOnly = True
        GridColumnDescriptor30.SerializedImageArray = ""
        GridColumnDescriptor31.HeaderImage = Nothing
        GridColumnDescriptor31.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor31.MappingName = "tasa"
        GridColumnDescriptor31.ReadOnly = True
        GridColumnDescriptor31.SerializedImageArray = ""
        GridColumnDescriptor31.Width = 50
        GridColumnDescriptor32.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.HotTrack)
        GridColumnDescriptor32.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor32.HeaderImage = Nothing
        GridColumnDescriptor32.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor32.MappingName = "Preciomn"
        GridColumnDescriptor32.ReadOnly = True
        GridColumnDescriptor32.SerializedImageArray = ""
        GridColumnDescriptor32.Width = 70
        GridColumnDescriptor33.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer)))
        GridColumnDescriptor33.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor33.HeaderImage = Nothing
        GridColumnDescriptor33.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor33.MappingName = "Preciome"
        GridColumnDescriptor33.ReadOnly = True
        GridColumnDescriptor33.SerializedImageArray = ""
        GridColumnDescriptor33.Width = 70
        Me.dgvPreciosServicio.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor27, GridColumnDescriptor28, GridColumnDescriptor29, GridColumnDescriptor30, GridColumnDescriptor31, GridColumnDescriptor32, GridColumnDescriptor33})
        Me.dgvPreciosServicio.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvPreciosServicio.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvPreciosServicio.TableDescriptor.TopLevelGroupOptions.ShowCaption = True
        Me.dgvPreciosServicio.TableDescriptor.TopLevelGroupOptions.ShowColumnHeaders = False
        Me.dgvPreciosServicio.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Precio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoConfig"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tasa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Preciomn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Preciome")})
        Me.dgvPreciosServicio.Text = "GridGroupingControl2"
        Me.dgvPreciosServicio.TopLevelGroupOptions.ShowCaption = False
        Me.dgvPreciosServicio.VersionInfo = "12.4400.0.24"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(105, 29)
        Me.ToolStripButton3.Text = "Crear Servicio"
        '
        'frmServiciosPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(892, 486)
        Me.Controls.Add(Me.dgvServicio)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmServiciosPrecios"
        Me.ShowIcon = False
        Me.Text = "Servicios Precios"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvPreciosServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Private WithEvents dgvServicio As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvPreciosServicio As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ToolStripButton3 As ToolStripButton
End Class
