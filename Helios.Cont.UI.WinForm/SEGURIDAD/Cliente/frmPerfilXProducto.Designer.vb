<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPerfilXProducto
    Inherits frmMaster

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfilXProducto))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboProducto = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboPErfil = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dgPerfilAutoriza = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1.SuspendLayout()
        CType(Me.cboProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.cboPErfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgPerfilAutoriza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboProducto)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.cboPErfil)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GradientPanel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 61)
        Me.Panel1.TabIndex = 410
        '
        'cboProducto
        '
        Me.cboProducto.BackColor = System.Drawing.Color.White
        Me.cboProducto.BeforeTouchSize = New System.Drawing.Size(206, 21)
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProducto.Location = New System.Drawing.Point(5, 24)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(206, 21)
        Me.cboProducto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboProducto.TabIndex = 457
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 14)
        Me.Label2.TabIndex = 456
        Me.Label2.Text = "Producto"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Location = New System.Drawing.Point(559, 23)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(93, 27)
        Me.GradientPanel1.TabIndex = 455
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(93, 27)
        Me.ButtonAdv1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(93, 27)
        Me.ButtonAdv1.TabIndex = 1
        Me.ButtonAdv1.Text = "Grabar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'cboPErfil
        '
        Me.cboPErfil.BackColor = System.Drawing.Color.White
        Me.cboPErfil.BeforeTouchSize = New System.Drawing.Size(236, 21)
        Me.cboPErfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPErfil.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPErfil.Location = New System.Drawing.Point(217, 24)
        Me.cboPErfil.Name = "cboPErfil"
        Me.cboPErfil.Size = New System.Drawing.Size(236, 21)
        Me.cboPErfil.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboPErfil.TabIndex = 454
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(217, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 453
        Me.Label1.Text = "Seleccionar perfil"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel8.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel8.Location = New System.Drawing.Point(462, 23)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(93, 27)
        Me.GradientPanel8.TabIndex = 452
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(93, 27)
        Me.ButtonAdv2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(93, 27)
        Me.ButtonAdv2.TabIndex = 1
        Me.ButtonAdv2.Text = "Consultar"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Snow
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(755, 37)
        Me.Panel4.TabIndex = 409
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(165, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "/ Mantenimiento"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.Label19.Image = CType(resources.GetObject("Label19.Image"), System.Drawing.Image)
        Me.Label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label19.Location = New System.Drawing.Point(5, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(160, 25)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "MOULOS DE SISTEMA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgPerfilAutoriza
        '
        Me.dgPerfilAutoriza.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgPerfilAutoriza.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgPerfilAutoriza.BackColor = System.Drawing.SystemColors.Window
        Me.dgPerfilAutoriza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPerfilAutoriza.FreezeCaption = False
        Me.dgPerfilAutoriza.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgPerfilAutoriza.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgPerfilAutoriza.Location = New System.Drawing.Point(0, 98)
        Me.dgPerfilAutoriza.Name = "dgPerfilAutoriza"
        Me.dgPerfilAutoriza.Size = New System.Drawing.Size(755, 238)
        Me.dgPerfilAutoriza.TabIndex = 411
        Me.dgPerfilAutoriza.TableDescriptor.AllowNew = False
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgPerfilAutoriza.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "IDAsegurable"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 36
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "Nombre"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 372
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "modulo"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 150
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CheckBoxOptions.IndetermValue = "False"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "autorizado"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 70
        Me.dgPerfilAutoriza.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
        Me.dgPerfilAutoriza.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgPerfilAutoriza.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgPerfilAutoriza.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("IDAsegurable"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Nombre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("modulo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("autorizado")})
        Me.dgPerfilAutoriza.Text = "GridGroupingControl2"
        Me.dgPerfilAutoriza.VersionInfo = "12.4400.0.24"
        '
        'frmPerfilXProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(755, 336)
        Me.Controls.Add(Me.dgPerfilAutoriza)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmPerfilXProducto"
        Me.ShowIcon = False
        Me.Text = "Autorización"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.cboPErfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgPerfilAutoriza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboPErfil As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgPerfilAutoriza As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboProducto As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
End Class
