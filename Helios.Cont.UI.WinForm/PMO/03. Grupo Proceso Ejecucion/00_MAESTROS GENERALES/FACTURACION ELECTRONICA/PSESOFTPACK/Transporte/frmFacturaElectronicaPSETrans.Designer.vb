Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFacturaElectronicaPSETrans
    Inherits MetroForm

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lblIdPse = New System.Windows.Forms.Label()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.lblIdPse)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel1.Controls.Add(Me.txtPeriodo)
        Me.GradientPanel1.Controls.Add(Me.lblPeriodo)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.ComboBox1)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(523, 73)
        Me.GradientPanel1.TabIndex = 1
        '
        'lblIdPse
        '
        Me.lblIdPse.AutoSize = True
        Me.lblIdPse.Location = New System.Drawing.Point(351, 12)
        Me.lblIdPse.Name = "lblIdPse"
        Me.lblIdPse.Size = New System.Drawing.Size(13, 13)
        Me.lblIdPse.TabIndex = 549
        Me.lblIdPse.Text = "0"
        Me.lblIdPse.Visible = False
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.BackColor = System.Drawing.Color.DodgerBlue
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(96, 34)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(384, 29)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(96, 34)
        Me.ButtonAdv2.TabIndex = 548
        Me.ButtonAdv2.Text = "Enviar al PSE"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPeriodo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtPeriodo.Calendar.AllowMultipleSelection = False
        Me.txtPeriodo.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtPeriodo.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtPeriodo.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtPeriodo.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPeriodo.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtPeriodo.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.Iso8601CalenderFormat = False
        Me.txtPeriodo.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodo.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.Name = "monthCalendar"
        Me.txtPeriodo.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtPeriodo.Calendar.SelectedDates = New Date(-1) {}
        Me.txtPeriodo.Calendar.Size = New System.Drawing.Size(85, 174)
        Me.txtPeriodo.Calendar.SizeToFit = True
        Me.txtPeriodo.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.Calendar.TabIndex = 0
        Me.txtPeriodo.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtPeriodo.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodo.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodo.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.NoneButton.IsBackStageButton = False
        Me.txtPeriodo.Calendar.NoneButton.Location = New System.Drawing.Point(13, 0)
        Me.txtPeriodo.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtPeriodo.Calendar.NoneButton.Text = "None"
        Me.txtPeriodo.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtPeriodo.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodo.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodo.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.TodayButton.IsBackStageButton = False
        Me.txtPeriodo.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodo.Calendar.TodayButton.Size = New System.Drawing.Size(13, 20)
        Me.txtPeriodo.Calendar.TodayButton.Text = "Today"
        Me.txtPeriodo.Calendar.TodayButton.UseVisualStyle = True
        Me.txtPeriodo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Checked = False
        Me.txtPeriodo.CustomFormat = "MM/yyyy"
        Me.txtPeriodo.DropDownImage = Nothing
        Me.txtPeriodo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodo.Location = New System.Drawing.Point(153, 11)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.ShowUpDown = True
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 545
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.Location = New System.Drawing.Point(13, 18)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(48, 13)
        Me.lblPeriodo.TabIndex = 544
        Me.lblPeriodo.Text = "Período"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Tipo de Documento:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"FACTURA", "NOTAS DE CREDITO", "NOTAS DE DEBITO", "BOLETAS"})
        Me.ComboBox1.Location = New System.Drawing.Point(153, 42)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 21)
        Me.ComboBox1.TabIndex = 8
        Me.ComboBox1.Text = "FACTURA"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BackColor = System.Drawing.Color.DodgerBlue
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(75, 34)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(303, 29)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(75, 34)
        Me.ButtonAdv1.TabIndex = 4
        Me.ButtonAdv1.Text = "Consultar"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.GridGroupingControl1)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 73)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(523, 357)
        Me.GradientPanel2.TabIndex = 2
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.FreezeCaption = False
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.Size = New System.Drawing.Size(523, 357)
        Me.GridGroupingControl1.TabIndex = 1
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "serie"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 80
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "numero"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 100
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "tipodoc"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "importe"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 70
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "enviosunat"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 0
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "fecha"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        Me.GridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.GridGroupingControl1.TableOptions.AllowDragColumns = False
        Me.GridGroupingControl1.TableOptions.AllowDropDownCell = False
        Me.GridGroupingControl1.TableOptions.AllowMultiColumnSort = False
        Me.GridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        Me.GridGroupingControl1.TableOptions.AllowSortColumns = False
        Me.GridGroupingControl1.Text = "GridGroupingControl1"
        Me.GridGroupingControl1.VersionInfo = "12.4400.0.24"
        '
        'frmFacturaElectronicaPSETrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.Purple
        Me.CaptionBarColor = System.Drawing.Color.Purple
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(250, 24)
        CaptionLabel1.Text = "ENVIO DE DOCUMENTOS AL PSE"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(523, 430)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "frmFacturaElectronicaPSETrans"
        Me.ShowIcon = False
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lblIdPse As Label


End Class
