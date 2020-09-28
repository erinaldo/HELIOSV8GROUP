<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreciosObservados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreciosObservados))
        Dim GridColumnDescriptor40 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor41 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor42 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor43 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor44 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor45 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor46 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor47 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor48 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor49 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor50 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor51 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor52 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvAlertas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dgvHistorialAlertas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvAlertas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvHistorialAlertas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
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
        Me.Panel2.Size = New System.Drawing.Size(908, 37)
        Me.Panel2.TabIndex = 449
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(114, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "/ Artículos con precios obervados"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EXISTENCIAS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvAlertas
        '
        Me.dgvAlertas.BackColor = System.Drawing.Color.MintCream
        Me.dgvAlertas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAlertas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAlertas.FreezeCaption = False
        Me.dgvAlertas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvAlertas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvAlertas.Location = New System.Drawing.Point(0, 69)
        Me.dgvAlertas.Name = "dgvAlertas"
        Me.dgvAlertas.Size = New System.Drawing.Size(908, 315)
        Me.dgvAlertas.TabIndex = 450
        Me.dgvAlertas.TableDescriptor.AllowNew = False
        GridColumnDescriptor40.HeaderImage = Nothing
        GridColumnDescriptor40.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor40.MappingName = "idalmacen"
        GridColumnDescriptor40.ReadOnly = True
        GridColumnDescriptor40.SerializedImageArray = ""
        GridColumnDescriptor40.Width = 50
        GridColumnDescriptor41.HeaderImage = Nothing
        GridColumnDescriptor41.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor41.MappingName = "almacen"
        GridColumnDescriptor41.ReadOnly = True
        GridColumnDescriptor41.SerializedImageArray = ""
        GridColumnDescriptor41.Width = 120
        GridColumnDescriptor42.HeaderImage = Nothing
        GridColumnDescriptor42.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor42.MappingName = "idAlerta"
        GridColumnDescriptor42.Name = "idAlerta"
        GridColumnDescriptor42.SerializedImageArray = ""
        GridColumnDescriptor43.HeaderImage = Nothing
        GridColumnDescriptor43.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor43.HeaderText = "Descripción"
        GridColumnDescriptor43.MappingName = "descripcion"
        GridColumnDescriptor43.Name = "descripcion"
        GridColumnDescriptor43.SerializedImageArray = ""
        GridColumnDescriptor43.Width = 250
        GridColumnDescriptor44.HeaderImage = Nothing
        GridColumnDescriptor44.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor44.HeaderText = "Ultima entrada"
        GridColumnDescriptor44.MappingName = "fechaInicio"
        GridColumnDescriptor44.Name = "fechaInicio"
        GridColumnDescriptor44.SerializedImageArray = ""
        GridColumnDescriptor44.Width = 150
        GridColumnDescriptor45.HeaderImage = Nothing
        GridColumnDescriptor45.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor45.HeaderText = "Ultima config."
        GridColumnDescriptor45.MappingName = "fechaFin"
        GridColumnDescriptor45.Name = "fechaFin"
        GridColumnDescriptor45.SerializedImageArray = ""
        GridColumnDescriptor45.Width = 150
        Me.dgvAlertas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor40, GridColumnDescriptor41, GridColumnDescriptor42, GridColumnDescriptor43, GridColumnDescriptor44, GridColumnDescriptor45})
        Me.dgvAlertas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvAlertas.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvAlertas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaInicio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaFin")})
        Me.dgvAlertas.Text = "GridGroupingControl1"
        Me.dgvAlertas.TopLevelGroupOptions.ShowCaption = False
        Me.dgvAlertas.VersionInfo = "12.4400.0.24"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.dgvHistorialAlertas)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 384)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(908, 100)
        Me.Panel7.TabIndex = 451
        '
        'dgvHistorialAlertas
        '
        Me.dgvHistorialAlertas.BackColor = System.Drawing.Color.MintCream
        Me.dgvHistorialAlertas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvHistorialAlertas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistorialAlertas.FreezeCaption = False
        Me.dgvHistorialAlertas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvHistorialAlertas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Custom
        Me.dgvHistorialAlertas.Location = New System.Drawing.Point(0, 0)
        Me.dgvHistorialAlertas.Name = "dgvHistorialAlertas"
        Me.dgvHistorialAlertas.Size = New System.Drawing.Size(908, 100)
        Me.dgvHistorialAlertas.TabIndex = 429
        Me.dgvHistorialAlertas.TableDescriptor.AllowNew = False
        GridColumnDescriptor46.HeaderImage = Nothing
        GridColumnDescriptor46.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor46.HeaderText = "Fecha"
        GridColumnDescriptor46.MappingName = "fecha"
        GridColumnDescriptor46.ReadOnly = True
        GridColumnDescriptor46.SerializedImageArray = ""
        GridColumnDescriptor46.Width = 180
        GridColumnDescriptor47.HeaderImage = Nothing
        GridColumnDescriptor47.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor47.MappingName = "idPrecio"
        GridColumnDescriptor47.ReadOnly = True
        GridColumnDescriptor47.SerializedImageArray = ""
        GridColumnDescriptor47.Width = 10
        GridColumnDescriptor48.HeaderImage = Nothing
        GridColumnDescriptor48.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor48.MappingName = "Precio"
        GridColumnDescriptor48.ReadOnly = True
        GridColumnDescriptor48.SerializedImageArray = ""
        GridColumnDescriptor48.Width = 200
        GridColumnDescriptor49.HeaderImage = Nothing
        GridColumnDescriptor49.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor49.MappingName = "tipoConfig"
        GridColumnDescriptor49.ReadOnly = True
        GridColumnDescriptor49.SerializedImageArray = ""
        GridColumnDescriptor50.HeaderImage = Nothing
        GridColumnDescriptor50.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor50.MappingName = "tasa"
        GridColumnDescriptor50.ReadOnly = True
        GridColumnDescriptor50.SerializedImageArray = ""
        GridColumnDescriptor50.Width = 50
        GridColumnDescriptor51.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.HotTrack)
        GridColumnDescriptor51.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor51.HeaderImage = Nothing
        GridColumnDescriptor51.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor51.MappingName = "Preciomn"
        GridColumnDescriptor51.ReadOnly = True
        GridColumnDescriptor51.SerializedImageArray = ""
        GridColumnDescriptor51.Width = 70
        GridColumnDescriptor52.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer)))
        GridColumnDescriptor52.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor52.HeaderImage = Nothing
        GridColumnDescriptor52.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor52.MappingName = "Preciome"
        GridColumnDescriptor52.ReadOnly = True
        GridColumnDescriptor52.SerializedImageArray = ""
        GridColumnDescriptor52.Width = 70
        Me.dgvHistorialAlertas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor46, GridColumnDescriptor47, GridColumnDescriptor48, GridColumnDescriptor49, GridColumnDescriptor50, GridColumnDescriptor51, GridColumnDescriptor52})
        Me.dgvHistorialAlertas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvHistorialAlertas.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvHistorialAlertas.TableDescriptor.TopLevelGroupOptions.ShowCaption = True
        Me.dgvHistorialAlertas.TableDescriptor.TopLevelGroupOptions.ShowColumnHeaders = False
        Me.dgvHistorialAlertas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Precio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoConfig"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tasa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Preciomn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Preciome")})
        Me.dgvHistorialAlertas.Text = "GridGroupingControl2"
        Me.dgvHistorialAlertas.TopLevelGroupOptions.ShowCaption = False
        Me.dgvHistorialAlertas.VersionInfo = "12.4400.0.24"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 37)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(908, 32)
        Me.ToolStrip1.TabIndex = 452
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
        Me.ToolStripButton2.Size = New System.Drawing.Size(86, 29)
        Me.ToolStripButton2.Text = "Actualizar"
        '
        'frmPreciosObservados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(908, 484)
        Me.Controls.Add(Me.dgvAlertas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmPreciosObservados"
        Me.ShowIcon = False
        Me.Text = "Precios Observados"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvAlertas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        CType(Me.dgvHistorialAlertas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvAlertas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel7 As Panel
    Friend WithEvents dgvHistorialAlertas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
End Class
