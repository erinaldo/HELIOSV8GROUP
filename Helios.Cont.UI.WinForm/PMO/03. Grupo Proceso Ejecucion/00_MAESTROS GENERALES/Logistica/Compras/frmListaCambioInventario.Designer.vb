<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaCambioInventario
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaCambioInventario))
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
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GradientPanel17 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv19 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtAnioCompra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboMes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.dgvMov = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel23.SuspendLayout()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel17.SuspendLayout()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Panel23.Controls.Add(Me.Label25)
        Me.Panel23.Controls.Add(Me.Label26)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(0, 0)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(782, 37)
        Me.Panel23.TabIndex = 248
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(87, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(217, 13)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "/ Otras entradas, sálidas y transferencias."
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Image = CType(resources.GetObject("Label26.Image"), System.Drawing.Image)
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label26.Location = New System.Drawing.Point(5, 6)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(85, 25)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "LISTADO"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GradientPanel17
        '
        Me.GradientPanel17.BackColor = System.Drawing.Color.White
        Me.GradientPanel17.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel17.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel17.Controls.Add(Me.ButtonAdv19)
        Me.GradientPanel17.Controls.Add(Me.txtAnioCompra)
        Me.GradientPanel17.Controls.Add(Me.cboMes)
        Me.GradientPanel17.Controls.Add(Me.Label85)
        Me.GradientPanel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel17.Location = New System.Drawing.Point(0, 37)
        Me.GradientPanel17.Name = "GradientPanel17"
        Me.GradientPanel17.Size = New System.Drawing.Size(782, 37)
        Me.GradientPanel17.TabIndex = 251
        '
        'ButtonAdv19
        '
        Me.ButtonAdv19.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv19.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv19.BeforeTouchSize = New System.Drawing.Size(86, 23)
        Me.ButtonAdv19.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv19.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv19.Image = CType(resources.GetObject("ButtonAdv19.Image"), System.Drawing.Image)
        Me.ButtonAdv19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv19.IsBackStageButton = False
        Me.ButtonAdv19.Location = New System.Drawing.Point(253, 5)
        Me.ButtonAdv19.Name = "ButtonAdv19"
        Me.ButtonAdv19.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAdv19.TabIndex = 3
        Me.ButtonAdv19.Text = "Consultar"
        Me.ButtonAdv19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv19.UseVisualStyle = True
        '
        'txtAnioCompra
        '
        Me.txtAnioCompra.BackColor = System.Drawing.Color.White
        Me.txtAnioCompra.BeforeTouchSize = New System.Drawing.Size(56, 22)
        Me.txtAnioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnioCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAnioCompra.Location = New System.Drawing.Point(191, 6)
        Me.txtAnioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.Name = "txtAnioCompra"
        Me.txtAnioCompra.ReadOnly = True
        Me.txtAnioCompra.Size = New System.Drawing.Size(56, 22)
        Me.txtAnioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAnioCompra.TabIndex = 2
        Me.txtAnioCompra.Text = "2016"
        Me.txtAnioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMes
        '
        Me.cboMes.BackColor = System.Drawing.Color.White
        Me.cboMes.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.Location = New System.Drawing.Point(65, 7)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(121, 21)
        Me.cboMes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMes.TabIndex = 1
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(14, 12)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(47, 13)
        Me.Label85.TabIndex = 0
        Me.Label85.Text = "Período"
        '
        'dgvMov
        '
        Me.dgvMov.BackColor = System.Drawing.SystemColors.Window
        Me.dgvMov.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMov.FreezeCaption = False
        Me.dgvMov.Location = New System.Drawing.Point(0, 74)
        Me.dgvMov.Name = "dgvMov"
        Me.dgvMov.Size = New System.Drawing.Size(782, 313)
        Me.dgvMov.TabIndex = 252
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer)))
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Mov."
        GridColumnDescriptor1.MappingName = "destino"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 150
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Fecha"
        GridColumnDescriptor2.MappingName = "fechaDoc"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 120
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Tipo Doc."
        GridColumnDescriptor3.MappingName = "tipoDoc"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 70
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Serie"
        GridColumnDescriptor4.MappingName = "serie"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "número"
        GridColumnDescriptor5.MappingName = "numeroDoc"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 120
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Doc Entidad"
        GridColumnDescriptor6.MappingName = "tipoDocEntidad"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "NroDoc"
        GridColumnDescriptor7.MappingName = "NroDocEntidad"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Entidad"
        GridColumnDescriptor8.MappingName = "NombreEntidad"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Tipo"
        GridColumnDescriptor9.MappingName = "TipoPersona"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "M.N."
        GridColumnDescriptor10.MappingName = "importeTotal"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 70
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "T/c"
        GridColumnDescriptor11.MappingName = "tcDolLoc"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 50
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "M.E."
        GridColumnDescriptor12.MappingName = "importeUS"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 70
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "Moneda"
        GridColumnDescriptor13.MappingName = "monedaDoc"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 0
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "idDocumento"
        GridColumnDescriptor14.SerializedImageArray = ""
        Me.dgvMov.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14})
        Me.dgvMov.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("destino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("serie"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numeroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDocEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NroDocEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombreEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TipoPersona"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeTotal"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tcDolLoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeUS"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monedaDoc")})
        Me.dgvMov.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvMov.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvMov.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvMov.Text = "dgvMov"
        Me.dgvMov.VersionInfo = "12.2400.0.20"
        '
        'frmListaCambioInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(782, 387)
        Me.Controls.Add(Me.dgvMov)
        Me.Controls.Add(Me.GradientPanel17)
        Me.Controls.Add(Me.Panel23)
        Me.Name = "frmListaCambioInventario"
        Me.ShowIcon = False
        Me.Text = "Cambios de Inventario"
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel17.ResumeLayout(False)
        Me.GradientPanel17.PerformLayout()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel17 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv19 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtAnioCompra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboMes As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Private WithEvents dgvMov As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
