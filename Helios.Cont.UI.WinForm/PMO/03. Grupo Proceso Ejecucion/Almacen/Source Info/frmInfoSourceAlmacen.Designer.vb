<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoSourceAlmacen
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.checkBox4 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.checkBox3 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.checkBox2 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.checkBox1 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.comboBoxAdv2 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GDBSource = New Syncfusion.Windows.Forms.Grid.GridDataBoundGrid()
        Me.fechaDoc = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.fechaContable = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.tipoDoc = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.serie = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.numeroDoc = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.Proveedor = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.monedaDoc = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.tasaIgv = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.tcDolLoc = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.importeTotal = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.importeUS = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.Glosa = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.panel1.SuspendLayout()
        CType(Me.checkBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.comboBoxAdv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GDBSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.checkBox4)
        Me.panel1.Controls.Add(Me.checkBox3)
        Me.panel1.Controls.Add(Me.checkBox2)
        Me.panel1.Controls.Add(Me.checkBox1)
        Me.panel1.Controls.Add(Me.groupBox1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.panel1.Location = New System.Drawing.Point(872, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(0, 426)
        Me.panel1.TabIndex = 3
        '
        'checkBox4
        '
        Me.checkBox4.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox4.Checked = True
        Me.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBox4.DrawFocusRectangle = False
        Me.checkBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox4.Location = New System.Drawing.Point(15, 121)
        Me.checkBox4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox4.Name = "checkBox4"
        Me.checkBox4.Size = New System.Drawing.Size(141, 21)
        Me.checkBox4.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox4.TabIndex = 4
        Me.checkBox4.Text = "BrowseOnly"
        Me.checkBox4.ThemesEnabled = False
        '
        'checkBox3
        '
        Me.checkBox3.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox3.DrawFocusRectangle = False
        Me.checkBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox3.Location = New System.Drawing.Point(15, 85)
        Me.checkBox3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox3.Name = "checkBox3"
        Me.checkBox3.Size = New System.Drawing.Size(141, 18)
        Me.checkBox3.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox3.TabIndex = 3
        Me.checkBox3.Text = "ApplyRoundedCorner"
        Me.checkBox3.ThemesEnabled = False
        '
        'checkBox2
        '
        Me.checkBox2.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox2.Checked = True
        Me.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBox2.DrawFocusRectangle = False
        Me.checkBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox2.Location = New System.Drawing.Point(15, 50)
        Me.checkBox2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox2.Name = "checkBox2"
        Me.checkBox2.Size = New System.Drawing.Size(141, 17)
        Me.checkBox2.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox2.TabIndex = 2
        Me.checkBox2.Text = "ShowCaption"
        Me.checkBox2.ThemesEnabled = False
        '
        'checkBox1
        '
        Me.checkBox1.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox1.Checked = True
        Me.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBox1.DrawFocusRectangle = False
        Me.checkBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox1.Location = New System.Drawing.Point(15, 12)
        Me.checkBox1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(141, 18)
        Me.checkBox1.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox1.TabIndex = 1
        Me.checkBox1.Text = "ShowCardCellBorders"
        Me.checkBox1.ThemesEnabled = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.comboBoxAdv2)
        Me.groupBox1.Controls.Add(Me.ComboBoxAdv1)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(5, 159)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(165, 135)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Style"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(10, 71)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(55, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "CardStyle"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(10, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Visual Style"
        '
        'comboBoxAdv2
        '
        Me.comboBoxAdv2.BackColor = System.Drawing.Color.White
        Me.comboBoxAdv2.BeforeTouchSize = New System.Drawing.Size(121, 19)
        Me.comboBoxAdv2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboBoxAdv2.Items.AddRange(New Object() {"StandardLabels", "MergedLabels"})
        Me.comboBoxAdv2.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.comboBoxAdv2, "StandardLabels"))
        Me.comboBoxAdv2.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.comboBoxAdv2, "MergedLabels"))
        Me.comboBoxAdv2.Location = New System.Drawing.Point(30, 95)
        Me.comboBoxAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.comboBoxAdv2.Name = "comboBoxAdv2"
        Me.comboBoxAdv2.Size = New System.Drawing.Size(121, 19)
        Me.comboBoxAdv2.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.comboBoxAdv2.TabIndex = 1
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(121, 19)
        Me.ComboBoxAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv1.Items.AddRange(New Object() {"Office2010Blue", "Office2010Black", "Office2010Silver", "Office2007Blue", "Office2007Black", "Office2007Silver", "Metro", "System", "None"})
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2010Blue"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2010Black"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2010Silver"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2007Blue"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2007Black"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2007Silver"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Metro"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "System"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "None"))
        Me.ComboBoxAdv1.Location = New System.Drawing.Point(30, 42)
        Me.ComboBoxAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        Me.ComboBoxAdv1.Size = New System.Drawing.Size(121, 19)
        Me.ComboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv1.TabIndex = 0
        '
        'GDBSource
        '
        Me.GDBSource.AllowDragSelectedCols = True
        Me.GDBSource.BackColor = System.Drawing.Color.White
        Me.GDBSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GDBSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GDBSource.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GDBSource.GridBoundColumns.AddRange(New Syncfusion.Windows.Forms.Grid.GridBoundColumn() {Me.fechaDoc, Me.fechaContable, Me.tipoDoc, Me.serie, Me.numeroDoc, Me.Proveedor, Me.monedaDoc, Me.tasaIgv, Me.tcDolLoc, Me.importeTotal, Me.importeUS, Me.Glosa})
        'Me.GDBSource.IsSpreadsheetFillSeries = False
        Me.GDBSource.Location = New System.Drawing.Point(0, 0)
        Me.GDBSource.Name = "GDBSource"
        Me.GDBSource.OptimizeInsertRemoveCells = True
        Me.GDBSource.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GDBSource.Size = New System.Drawing.Size(872, 426)
        Me.GDBSource.SmartSizeBox = False
        Me.GDBSource.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.DoubleClick
        'Me.GDBSource.SpreadsheetLikeSelection = False
        Me.GDBSource.TabIndex = 4
        Me.GDBSource.Text = "gridDataBoundGrid1"
        Me.GDBSource.ThemesEnabled = True
        Me.GDBSource.UseListChangedEvent = True
        Me.GDBSource.UseRightToLeftCompatibleTextBox = True
        '
        'fechaDoc
        '
        Me.fechaDoc.HeaderText = "Fecha compra"
        Me.fechaDoc.Hidden = False
        Me.fechaDoc.MappingName = "fechaDoc"
        Me.fechaDoc.Position = 1
        Me.fechaDoc.Width = -1
        '
        'fechaContable
        '
        Me.fechaContable.HeaderText = "Período"
        Me.fechaContable.Hidden = False
        Me.fechaContable.MappingName = "fechaContable"
        Me.fechaContable.Position = 2
        Me.fechaContable.Width = -1
        '
        'tipoDoc
        '
        Me.tipoDoc.HeaderText = "Tipo Doc."
        Me.tipoDoc.Hidden = False
        Me.tipoDoc.MappingName = "tipoDoc"
        Me.tipoDoc.Position = 3
        Me.tipoDoc.Width = -1
        '
        'serie
        '
        Me.serie.HeaderText = "Serie"
        Me.serie.Hidden = False
        Me.serie.MappingName = "serie"
        Me.serie.Position = 4
        Me.serie.Width = -1
        '
        'numeroDoc
        '
        Me.numeroDoc.HeaderText = "Número"
        Me.numeroDoc.Hidden = False
        Me.numeroDoc.MappingName = "numeroDoc"
        Me.numeroDoc.Position = 5
        Me.numeroDoc.Width = -1
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Hidden = False
        Me.Proveedor.MappingName = "Proveedor"
        Me.Proveedor.Position = 6
        Me.Proveedor.Width = -1
        '
        'monedaDoc
        '
        Me.monedaDoc.HeaderText = "Moneda"
        Me.monedaDoc.Hidden = False
        Me.monedaDoc.MappingName = "monedaDoc"
        Me.monedaDoc.Position = 7
        Me.monedaDoc.Width = -1
        '
        'tasaIgv
        '
        Me.tasaIgv.HeaderText = "Tasa I.g.v."
        Me.tasaIgv.Hidden = False
        Me.tasaIgv.MappingName = "tasaIgv"
        Me.tasaIgv.Position = 8
        Me.tasaIgv.Width = -1
        '
        'tcDolLoc
        '
        Me.tcDolLoc.HeaderText = "Tipo cambio"
        Me.tcDolLoc.Hidden = False
        Me.tcDolLoc.MappingName = "tcDolLoc"
        Me.tcDolLoc.Position = 9
        Me.tcDolLoc.Width = -1
        '
        'importeTotal
        '
        Me.importeTotal.HeaderText = "Importe (MN.)"
        Me.importeTotal.Hidden = False
        Me.importeTotal.MappingName = "importeTotal"
        Me.importeTotal.Position = 10
        Me.importeTotal.Width = -1
        '
        'importeUS
        '
        Me.importeUS.HeaderText = "Importe (ME.)"
        Me.importeUS.Hidden = False
        Me.importeUS.MappingName = "importeUS"
        Me.importeUS.Position = 11
        Me.importeUS.Width = -1
        '
        'Glosa
        '
        Me.Glosa.HeaderText = "Glosa"
        Me.Glosa.Hidden = True
        Me.Glosa.MappingName = "Glosa"
        Me.Glosa.Position = 12
        Me.Glosa.StyleInfo.TriState = True
        Me.Glosa.StyleInfo.WrapText = True
        Me.Glosa.Width = -1
        '
        'frmInfoSourceAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(872, 426)
        Me.Controls.Add(Me.GDBSource)
        Me.Controls.Add(Me.panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoSourceAlmacen"
        Me.ShowIcon = False
        Me.Text = "Source"
        Me.panel1.ResumeLayout(False)
        CType(Me.checkBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.checkBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.checkBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.checkBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.comboBoxAdv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GDBSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents checkBox4 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Private WithEvents checkBox3 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Private WithEvents checkBox2 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Private WithEvents checkBox1 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents comboBoxAdv2 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Private WithEvents ComboBoxAdv1 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Public WithEvents GDBSource As Syncfusion.Windows.Forms.Grid.GridDataBoundGrid
    Friend WithEvents fechaDoc As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents fechaContable As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents tipoDoc As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents serie As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents numeroDoc As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents Proveedor As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents monedaDoc As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents tasaIgv As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents tcDolLoc As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents importeTotal As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents importeUS As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents Glosa As Syncfusion.Windows.Forms.Grid.GridBoundColumn
End Class
