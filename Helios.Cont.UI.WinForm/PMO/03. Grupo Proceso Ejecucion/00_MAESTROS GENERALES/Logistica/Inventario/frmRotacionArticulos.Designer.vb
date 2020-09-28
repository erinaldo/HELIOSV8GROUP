<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRotacionArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRotacionArticulos))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cboConsultaRotacion = New System.Windows.Forms.ComboBox()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.NumericUpDownExt1 = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.txtDiasAtraso = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtfecFin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtfecInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.dgvRotacion = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel27.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.NumericUpDownExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasAtraso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecFin.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRotacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Panel27.Controls.Add(Me.Label39)
        Me.Panel27.Controls.Add(Me.Label40)
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel27.Location = New System.Drawing.Point(0, 0)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(1237, 37)
        Me.Panel27.TabIndex = 249
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(173, 12)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(105, 13)
        Me.Label39.TabIndex = 2
        Me.Label39.Text = "/ Control y análisis."
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Image = CType(resources.GetObject("Label40.Image"), System.Drawing.Image)
        Me.Label40.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label40.Location = New System.Drawing.Point(5, 6)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(168, 25)
        Me.Label40.TabIndex = 0
        Me.Label40.Text = "ROTACION EXISTENCIAS"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Label41)
        Me.Panel9.Controls.Add(Me.Label42)
        Me.Panel9.Controls.Add(Me.cboConsultaRotacion)
        Me.Panel9.Controls.Add(Me.ButtonAdv2)
        Me.Panel9.Controls.Add(Me.NumericUpDownExt1)
        Me.Panel9.Controls.Add(Me.CheckBox2)
        Me.Panel9.Controls.Add(Me.txtDiasAtraso)
        Me.Panel9.Controls.Add(Me.Label43)
        Me.Panel9.Controls.Add(Me.Label44)
        Me.Panel9.Controls.Add(Me.Label45)
        Me.Panel9.Controls.Add(Me.txtfecFin)
        Me.Panel9.Controls.Add(Me.txtfecInicio)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 37)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1237, 66)
        Me.Panel9.TabIndex = 424
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label41.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label41.Location = New System.Drawing.Point(1004, 10)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(145, 19)
        Me.Label41.TabIndex = 427
        Me.Label41.Text = "FILTRO PERSONALIZADO"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label41.Visible = False
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label42.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label42.Location = New System.Drawing.Point(341, 12)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(145, 19)
        Me.Label42.TabIndex = 426
        Me.Label42.Text = "CANTIDAD DE BUSQUEDA"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboConsultaRotacion
        '
        Me.cboConsultaRotacion.FormattingEnabled = True
        Me.cboConsultaRotacion.Items.AddRange(New Object() {"0 - 10 unidades", "11 - 100 unidades", "101 - 500 unidades", "501 - a mas", "0 - a mas"})
        Me.cboConsultaRotacion.Location = New System.Drawing.Point(344, 37)
        Me.cboConsultaRotacion.Name = "cboConsultaRotacion"
        Me.cboConsultaRotacion.Size = New System.Drawing.Size(143, 21)
        Me.cboConsultaRotacion.TabIndex = 424
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(95, 32)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(503, 26)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(95, 32)
        Me.ButtonAdv2.TabIndex = 423
        Me.ButtonAdv2.Text = "Consultar"
        Me.ButtonAdv2.UseVisualStyle = True
        Me.ButtonAdv2.UseVisualStyleBackColor = False
        '
        'NumericUpDownExt1
        '
        Me.NumericUpDownExt1.BeforeTouchSize = New System.Drawing.Size(59, 22)
        Me.NumericUpDownExt1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericUpDownExt1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.NumericUpDownExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDownExt1.Location = New System.Drawing.Point(1073, 36)
        Me.NumericUpDownExt1.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.NumericUpDownExt1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericUpDownExt1.Name = "NumericUpDownExt1"
        Me.NumericUpDownExt1.Size = New System.Drawing.Size(59, 22)
        Me.NumericUpDownExt1.TabIndex = 418
        Me.NumericUpDownExt1.ThousandsSeparator = True
        Me.NumericUpDownExt1.Value = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDownExt1.Visible = False
        Me.NumericUpDownExt1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(1007, 39)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(65, 17)
        Me.CheckBox2.TabIndex = 416
        Me.CheckBox2.Text = "De 0 a -"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'txtDiasAtraso
        '
        Me.txtDiasAtraso.BackColor = System.Drawing.Color.Chocolate
        Me.txtDiasAtraso.BeforeTouchSize = New System.Drawing.Size(90, 22)
        Me.txtDiasAtraso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiasAtraso.ForeColor = System.Drawing.Color.White
        Me.txtDiasAtraso.Location = New System.Drawing.Point(28, 36)
        Me.txtDiasAtraso.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.txtDiasAtraso.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDiasAtraso.Name = "txtDiasAtraso"
        Me.txtDiasAtraso.Size = New System.Drawing.Size(90, 22)
        Me.txtDiasAtraso.TabIndex = 415
        Me.txtDiasAtraso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDiasAtraso.ThemesEnabled = True
        Me.txtDiasAtraso.ThousandsSeparator = True
        Me.txtDiasAtraso.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label43.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label43.Location = New System.Drawing.Point(25, 12)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(93, 19)
        Me.Label43.TabIndex = 305
        Me.Label43.Text = "DIAS DE ATRASO"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label44.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label44.Location = New System.Drawing.Point(233, 12)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(74, 19)
        Me.Label44.TabIndex = 303
        Me.Label44.Text = "FECHA FIN"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label45.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label45.Location = New System.Drawing.Point(130, 12)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(80, 19)
        Me.Label45.TabIndex = 302
        Me.Label45.Text = "FECHA INICIO"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtfecFin
        '
        Me.txtfecFin.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtfecFin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtfecFin.Calendar.AllowMultipleSelection = False
        Me.txtfecFin.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecFin.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfecFin.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfecFin.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecFin.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtfecFin.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtfecFin.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtfecFin.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecFin.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfecFin.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtfecFin.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtfecFin.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtfecFin.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtfecFin.Calendar.Iso8601CalenderFormat = False
        Me.txtfecFin.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtfecFin.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecFin.Calendar.Name = "monthCalendar"
        Me.txtfecFin.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtfecFin.Calendar.SelectedDates = New Date(-1) {}
        Me.txtfecFin.Calendar.Size = New System.Drawing.Size(88, 174)
        Me.txtfecFin.Calendar.SizeToFit = True
        Me.txtfecFin.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecFin.Calendar.TabIndex = 0
        Me.txtfecFin.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtfecFin.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecFin.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecFin.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecFin.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtfecFin.Calendar.NoneButton.IsBackStageButton = False
        Me.txtfecFin.Calendar.NoneButton.Location = New System.Drawing.Point(16, 0)
        Me.txtfecFin.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtfecFin.Calendar.NoneButton.Text = "None"
        Me.txtfecFin.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtfecFin.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecFin.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecFin.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecFin.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtfecFin.Calendar.TodayButton.IsBackStageButton = False
        Me.txtfecFin.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtfecFin.Calendar.TodayButton.Size = New System.Drawing.Size(16, 20)
        Me.txtfecFin.Calendar.TodayButton.Text = "Today"
        Me.txtfecFin.Calendar.TodayButton.UseVisualStyle = True
        Me.txtfecFin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecFin.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtfecFin.CustomFormat = "dd/MM/yyyy"
        Me.txtfecFin.DropDownImage = Nothing
        Me.txtfecFin.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecFin.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecFin.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtfecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtfecFin.Location = New System.Drawing.Point(236, 38)
        Me.txtfecFin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecFin.MinValue = New Date(CType(0, Long))
        Me.txtfecFin.Name = "txtfecFin"
        Me.txtfecFin.ReadOnly = True
        Me.txtfecFin.ShowCheckBox = False
        Me.txtfecFin.ShowDropButton = False
        Me.txtfecFin.Size = New System.Drawing.Size(92, 20)
        Me.txtfecFin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecFin.TabIndex = 301
        Me.txtfecFin.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'txtfecInicio
        '
        Me.txtfecInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtfecInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtfecInicio.Calendar.AllowMultipleSelection = False
        Me.txtfecInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecInicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfecInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfecInicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecInicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtfecInicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtfecInicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtfecInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfecInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtfecInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtfecInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtfecInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtfecInicio.Calendar.Iso8601CalenderFormat = False
        Me.txtfecInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtfecInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecInicio.Calendar.Name = "monthCalendar"
        Me.txtfecInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtfecInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.txtfecInicio.Calendar.Size = New System.Drawing.Size(93, 174)
        Me.txtfecInicio.Calendar.SizeToFit = True
        Me.txtfecInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecInicio.Calendar.TabIndex = 0
        Me.txtfecInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtfecInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtfecInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtfecInicio.Calendar.NoneButton.Location = New System.Drawing.Point(21, 0)
        Me.txtfecInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtfecInicio.Calendar.NoneButton.Text = "None"
        Me.txtfecInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtfecInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtfecInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtfecInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtfecInicio.Calendar.TodayButton.Size = New System.Drawing.Size(21, 20)
        Me.txtfecInicio.Calendar.TodayButton.Text = "Today"
        Me.txtfecInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.txtfecInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtfecInicio.CustomFormat = "dd/MM/yyyy"
        Me.txtfecInicio.DropDownImage = Nothing
        Me.txtfecInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtfecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtfecInicio.Location = New System.Drawing.Point(133, 38)
        Me.txtfecInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecInicio.MinValue = New Date(CType(0, Long))
        Me.txtfecInicio.Name = "txtfecInicio"
        Me.txtfecInicio.ReadOnly = True
        Me.txtfecInicio.ShowCheckBox = False
        Me.txtfecInicio.ShowDropButton = False
        Me.txtfecInicio.Size = New System.Drawing.Size(97, 20)
        Me.txtfecInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecInicio.TabIndex = 300
        Me.txtfecInicio.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'dgvRotacion
        '
        Me.dgvRotacion.BackColor = System.Drawing.SystemColors.Window
        Me.dgvRotacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRotacion.FreezeCaption = False
        Me.dgvRotacion.Location = New System.Drawing.Point(0, 103)
        Me.dgvRotacion.Name = "dgvRotacion"
        Me.dgvRotacion.Size = New System.Drawing.Size(1237, 369)
        Me.dgvRotacion.TabIndex = 425
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idItem"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Descripcion"
        GridColumnDescriptor2.MappingName = "descripcion"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 200
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Cantidad"
        GridColumnDescriptor3.MappingName = "monto"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Stock Actual"
        GridColumnDescriptor4.MappingName = "stock"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Nombre Almacen"
        GridColumnDescriptor5.MappingName = "idalmacen"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 200
        Me.dgvRotacion.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.dgvRotacion.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvRotacion.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvRotacion.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvRotacion.Text = "gridGroupingControl1"
        Me.dgvRotacion.VersionInfo = "12.2400.0.20"
        '
        'frmRotacionArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1237, 472)
        Me.Controls.Add(Me.dgvRotacion)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel27)
        Me.Name = "frmRotacionArticulos"
        Me.ShowIcon = False
        Me.Text = "Consultar rotación de artículos"
        Me.Panel27.ResumeLayout(False)
        Me.Panel27.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.NumericUpDownExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasAtraso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecFin.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRotacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel27 As Panel
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Panel9 As Panel
    Private WithEvents Label41 As Label
    Private WithEvents Label42 As Label
    Friend WithEvents cboConsultaRotacion As ComboBox
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents NumericUpDownExt1 As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents txtDiasAtraso As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents Label43 As Label
    Private WithEvents Label44 As Label
    Private WithEvents Label45 As Label
    Friend WithEvents txtfecFin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtfecInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Private WithEvents dgvRotacion As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
