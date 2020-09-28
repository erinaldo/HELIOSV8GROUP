<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialCaja
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
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorialCaja))
        Me.dgvUsuarioActivo = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ToolStrip13 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton5 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton39 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton40 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton41 = New System.Windows.Forms.ToolStripButton()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        CType(Me.dgvUsuarioActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip13.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUsuarioActivo
        '
        Me.dgvUsuarioActivo.BackColor = System.Drawing.SystemColors.Window
        Me.dgvUsuarioActivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarioActivo.FreezeCaption = False
        Me.dgvUsuarioActivo.Location = New System.Drawing.Point(0, 69)
        Me.dgvUsuarioActivo.Name = "dgvUsuarioActivo"
        Me.dgvUsuarioActivo.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvUsuarioActivo.NestedTableGroupOptions.ShowCaption = False
        Me.dgvUsuarioActivo.Size = New System.Drawing.Size(814, 440)
        Me.dgvUsuarioActivo.TabIndex = 414
        Me.dgvUsuarioActivo.TableDescriptor.ChildGroupOptions.ShowCaption = False
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "idPersona"
        GridColumnDescriptor6.Name = "idPersona"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "idCaja"
        GridColumnDescriptor7.Name = "idCaja"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Nombre "
        GridColumnDescriptor8.MappingName = "nombre"
        GridColumnDescriptor8.Name = "nombre"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 350
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "DNI"
        GridColumnDescriptor9.Name = "DNI"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 100
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Estado"
        GridColumnDescriptor10.MappingName = "estado"
        GridColumnDescriptor10.Name = "estado"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 100
        Me.dgvUsuarioActivo.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        Me.dgvUsuarioActivo.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DNI"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.dgvUsuarioActivo.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvUsuarioActivo.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvUsuarioActivo.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvUsuarioActivo.Text = "GridGroupingControl1"
        Me.dgvUsuarioActivo.VersionInfo = "12.2400.0.20"
        '
        'ToolStrip13
        '
        Me.ToolStrip13.BackColor = System.Drawing.Color.White
        Me.ToolStrip13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip13.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip13.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton5, Me.ToolStripButton39, Me.ToolStripButton40, Me.ToolStripButton41})
        Me.ToolStrip13.Location = New System.Drawing.Point(0, 37)
        Me.ToolStrip13.Name = "ToolStrip13"
        Me.ToolStrip13.Size = New System.Drawing.Size(814, 32)
        Me.ToolStrip13.TabIndex = 415
        Me.ToolStrip13.Text = "ToolStrip13"
        '
        'ToolStripDropDownButton5
        '
        Me.ToolStripDropDownButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5})
        Me.ToolStripDropDownButton5.Image = CType(resources.GetObject("ToolStripDropDownButton5.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton5.Name = "ToolStripDropDownButton5"
        Me.ToolStripDropDownButton5.Size = New System.Drawing.Size(38, 29)
        Me.ToolStripDropDownButton5.Text = "&New"
        Me.ToolStripDropDownButton5.Visible = False
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripMenuItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(149, 22)
        Me.ToolStripMenuItem5.Text = "Nuevo usuario"
        '
        'ToolStripButton39
        '
        Me.ToolStripButton39.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton39.Image = CType(resources.GetObject("ToolStripButton39.Image"), System.Drawing.Image)
        Me.ToolStripButton39.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton39.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton39.Name = "ToolStripButton39"
        Me.ToolStripButton39.Size = New System.Drawing.Size(29, 29)
        Me.ToolStripButton39.Text = "&Editar"
        Me.ToolStripButton39.Visible = False
        '
        'ToolStripButton40
        '
        Me.ToolStripButton40.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton40.Image = CType(resources.GetObject("ToolStripButton40.Image"), System.Drawing.Image)
        Me.ToolStripButton40.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton40.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton40.Name = "ToolStripButton40"
        Me.ToolStripButton40.Size = New System.Drawing.Size(29, 29)
        Me.ToolStripButton40.Text = "&Borrar"
        Me.ToolStripButton40.Visible = False
        '
        'ToolStripButton41
        '
        Me.ToolStripButton41.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton41.Image = CType(resources.GetObject("ToolStripButton41.Image"), System.Drawing.Image)
        Me.ToolStripButton41.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton41.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton41.Name = "ToolStripButton41"
        Me.ToolStripButton41.Size = New System.Drawing.Size(29, 29)
        Me.ToolStripButton41.Text = "&Actulizar data"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel16.Controls.Add(Me.Label80)
        Me.Panel16.Controls.Add(Me.Label81)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(814, 37)
        Me.Panel16.TabIndex = 413
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(148, 12)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(51, 13)
        Me.Label80.TabIndex = 1
        Me.Label80.Text = "/ Listado"
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Black
        Me.Label81.Image = CType(resources.GetObject("Label81.Image"), System.Drawing.Image)
        Me.Label81.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label81.Location = New System.Drawing.Point(5, 6)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(144, 25)
        Me.Label81.TabIndex = 0
        Me.Label81.Text = "USUARIOS ACTIVOS"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmHistorialCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 509)
        Me.Controls.Add(Me.dgvUsuarioActivo)
        Me.Controls.Add(Me.ToolStrip13)
        Me.Controls.Add(Me.Panel16)
        Me.Name = "frmHistorialCaja"
        Me.ShowIcon = False
        Me.Text = "Lista de Usuarios de Caja - Activas"
        CType(Me.dgvUsuarioActivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip13.ResumeLayout(False)
        Me.ToolStrip13.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dgvUsuarioActivo As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ToolStrip13 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton5 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton39 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton40 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton41 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
End Class
