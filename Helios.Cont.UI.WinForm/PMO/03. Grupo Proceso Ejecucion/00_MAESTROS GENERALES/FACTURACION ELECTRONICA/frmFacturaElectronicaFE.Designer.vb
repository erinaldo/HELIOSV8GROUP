<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaElectronicaFE
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.dtpFechaDocs = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkFecha)
        Me.Panel1.Controls.Add(Me.chkPeriodo)
        Me.Panel1.Controls.Add(Me.txtPeriodo)
        Me.Panel1.Controls.Add(Me.lblPeriodo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblFecha)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.ButtonAdv2)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.dtpFechaDocs)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 153)
        Me.Panel1.TabIndex = 0
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
        Me.txtPeriodo.Calendar.Size = New System.Drawing.Size(79, 174)
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
        Me.txtPeriodo.Calendar.NoneButton.Location = New System.Drawing.Point(7, 0)
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
        Me.txtPeriodo.Calendar.TodayButton.Size = New System.Drawing.Size(7, 20)
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
        Me.txtPeriodo.Location = New System.Drawing.Point(177, 45)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.ShowUpDown = True
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 539
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        Me.txtPeriodo.Visible = False
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.Location = New System.Drawing.Point(12, 45)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(44, 14)
        Me.lblPeriodo.TabIndex = 538
        Me.lblPeriodo.Text = "Período"
        Me.lblPeriodo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tipo de Documento:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(12, 48)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(124, 13)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "Fecha de Documentos:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"FACTURA", "NOTAS DE CREDITO", "NOTAS DE DEBITO"})
        Me.ComboBox1.Location = New System.Drawing.Point(177, 72)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 21)
        Me.ComboBox1.TabIndex = 5
        Me.ComboBox1.Text = "FACTURA"
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(96, 34)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(100, 110)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(96, 34)
        Me.ButtonAdv2.TabIndex = 4
        Me.ButtonAdv2.Text = "Enviar a Sunat"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(75, 34)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(12, 110)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(75, 34)
        Me.ButtonAdv1.TabIndex = 3
        Me.ButtonAdv1.Text = "Consultar"
        '
        'dtpFechaDocs
        '
        Me.dtpFechaDocs.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDocs.Location = New System.Drawing.Point(177, 41)
        Me.dtpFechaDocs.Name = "dtpFechaDocs"
        Me.dtpFechaDocs.Size = New System.Drawing.Size(87, 22)
        Me.dtpFechaDocs.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridGroupingControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(359, 197)
        Me.Panel2.TabIndex = 1
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.FreezeCaption = False
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.Size = New System.Drawing.Size(359, 197)
        Me.GridGroupingControl1.TabIndex = 0
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
        Me.GridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6})
        Me.GridGroupingControl1.TableOptions.AllowDragColumns = False
        Me.GridGroupingControl1.TableOptions.AllowDropDownCell = False
        Me.GridGroupingControl1.TableOptions.AllowMultiColumnSort = False
        Me.GridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        Me.GridGroupingControl1.TableOptions.AllowSortColumns = False
        Me.GridGroupingControl1.Text = "GridGroupingControl1"
        Me.GridGroupingControl1.VersionInfo = "12.4400.0.24"
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.Location = New System.Drawing.Point(97, 12)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(86, 17)
        Me.chkPeriodo.TabIndex = 540
        Me.chkPeriodo.Text = "Por Periodo"
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'chkFecha
        '
        Me.chkFecha.AutoSize = True
        Me.chkFecha.Checked = True
        Me.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFecha.Location = New System.Drawing.Point(15, 12)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(76, 17)
        Me.chkFecha.TabIndex = 541
        Me.chkFecha.Text = "Por Fecha"
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'frmFacturaElectronicaFE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.SteelBlue
        Me.CaptionBarColor = System.Drawing.Color.SteelBlue
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(500, 24)
        CaptionLabel1.Text = "Facturas/Notas Electronicas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(359, 350)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmFacturaElectronicaFE"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents dtpFechaDocs As DateTimePicker
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents chkFecha As CheckBox
    Friend WithEvents chkPeriodo As CheckBox
End Class
