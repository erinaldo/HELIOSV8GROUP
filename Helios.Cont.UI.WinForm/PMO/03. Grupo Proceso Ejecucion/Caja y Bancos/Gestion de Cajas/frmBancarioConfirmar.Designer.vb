<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancarioConfirmar
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
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cboMonedaProveedor = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvbancario = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1.SuspendLayout()
        CType(Me.cboMonedaProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvbancario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.Label50)
        Me.Panel1.Controls.Add(Me.cboMonedaProveedor)
        Me.Panel1.Controls.Add(Me.txtPeriodo)
        Me.Panel1.Controls.Add(Me.Label52)
        Me.Panel1.Controls.Add(Me.ButtonAdv5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(938, 69)
        Me.Panel1.TabIndex = 0
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(236, 28)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(71, 26)
        Me.ButtonAdv1.TabIndex = 507
        Me.ButtonAdv1.Text = "Consultar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(15, 13)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(48, 13)
        Me.Label50.TabIndex = 506
        Me.Label50.Text = "MONEDA"
        '
        'cboMonedaProveedor
        '
        Me.cboMonedaProveedor.BackColor = System.Drawing.Color.White
        Me.cboMonedaProveedor.BeforeTouchSize = New System.Drawing.Size(106, 21)
        Me.cboMonedaProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonedaProveedor.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonedaProveedor.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMonedaProveedor.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMonedaProveedor, "NACIONAL"))
        Me.cboMonedaProveedor.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMonedaProveedor, "EXTRANJERA"))
        Me.cboMonedaProveedor.Location = New System.Drawing.Point(18, 33)
        Me.cboMonedaProveedor.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMonedaProveedor.Name = "cboMonedaProveedor"
        Me.cboMonedaProveedor.Size = New System.Drawing.Size(106, 21)
        Me.cboMonedaProveedor.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMonedaProveedor.TabIndex = 505
        Me.cboMonedaProveedor.Text = "NACIONAL"
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
        Me.txtPeriodo.Calendar.Size = New System.Drawing.Size(83, 174)
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
        Me.txtPeriodo.Calendar.NoneButton.Location = New System.Drawing.Point(11, 0)
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
        Me.txtPeriodo.Calendar.TodayButton.Size = New System.Drawing.Size(11, 20)
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
        Me.txtPeriodo.Location = New System.Drawing.Point(130, 34)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.ShowUpDown = True
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 504
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label52.Location = New System.Drawing.Point(127, 13)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(48, 13)
        Me.Label52.TabIndex = 503
        Me.Label52.Text = "PERIODO"
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(71, 33)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(421, 21)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(71, 33)
        Me.ButtonAdv5.TabIndex = 424
        Me.ButtonAdv5.Text = "Confirmar Pago"
        Me.ButtonAdv5.UseVisualStyle = True
        Me.ButtonAdv5.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvbancario)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(938, 361)
        Me.Panel2.TabIndex = 1
        '
        'dgvbancario
        '
        Me.dgvbancario.BackColor = System.Drawing.SystemColors.Window
        Me.dgvbancario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvbancario.FreezeCaption = False
        Me.dgvbancario.Location = New System.Drawing.Point(0, 0)
        Me.dgvbancario.Name = "dgvbancario"
        Me.dgvbancario.Size = New System.Drawing.Size(938, 361)
        Me.dgvbancario.TabIndex = 0
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "IdProveedor"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Razon"
        GridColumnDescriptor3.MappingName = "nombreCompleto"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 180
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "tipoEntidad"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 0
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "N°Doc"
        GridColumnDescriptor5.MappingName = "nrodoc"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 80
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "formapago"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 80
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "tipoDocPago"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 0
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Num.Doc"
        GridColumnDescriptor8.MappingName = "numeroDoc"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 90
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "FechaProceso"
        GridColumnDescriptor9.MappingName = "fechaProceso"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 90
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "MonthCalendar"
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "FechaCobro"
        GridColumnDescriptor10.MappingName = "fechaCobro"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 90
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Moneda"
        GridColumnDescriptor11.MappingName = "moneda"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 80
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Operacion"
        GridColumnDescriptor12.MappingName = "tipoOperacion"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 70
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "Importe"
        GridColumnDescriptor13.MappingName = "montoSoles"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 70
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "movimientoCaja"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 0
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "N°Op."
        GridColumnDescriptor15.MappingName = "numeroOperacion"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 80
        Me.dgvbancario.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15})
        Me.dgvbancario.TableOptions.AllowDragColumns = False
        Me.dgvbancario.TableOptions.AllowDropDownCell = False
        Me.dgvbancario.TableOptions.AllowMultiColumnSort = False
        Me.dgvbancario.TableOptions.AllowSortColumns = False
        Me.dgvbancario.Text = "GridGroupingControl1"
        Me.dgvbancario.VersionInfo = "12.4400.0.24"
        '
        'frmBancarioConfirmar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.Crimson
        Me.CaptionBarColor = System.Drawing.Color.Crimson
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(938, 430)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmBancarioConfirmar"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboMonedaProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvbancario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvbancario As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label50 As Label
    Friend WithEvents cboMonedaProveedor As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label52 As Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
End Class
