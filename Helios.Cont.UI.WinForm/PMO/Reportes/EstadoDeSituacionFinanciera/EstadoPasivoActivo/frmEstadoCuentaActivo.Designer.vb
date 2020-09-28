<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadoCuentaActivo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadoCuentaActivo))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtFechaInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LblCabezera = New System.Windows.Forms.Label()
        Me.LblTipoCuenta = New System.Windows.Forms.Label()
        Me.hhh = New System.Windows.Forms.Label()
        Me.rptCuentaActivo = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFin.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(884, 124)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 323)
        Me.Panel4.TabIndex = 35
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 124)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 323)
        Me.Panel3.TabIndex = 34
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 96)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(974, 28)
        Me.Panel2.TabIndex = 33
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtFechaFin)
        Me.Panel1.Controls.Add(Me.txtFechaInicio)
        Me.Panel1.Controls.Add(Me.ButtonAdv2)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.LblTipoCuenta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(974, 96)
        Me.Panel1.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 513
        Me.Label4.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 512
        Me.Label3.Text = "Desde:"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.BackColor = System.Drawing.Color.OrangeRed
        Me.txtFechaFin.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaFin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaFin.Calendar.AllowMultipleSelection = False
        Me.txtFechaFin.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFin.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaFin.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaFin.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFin.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaFin.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaFin.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaFin.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFin.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaFin.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaFin.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaFin.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaFin.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaFin.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFin.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFin.Calendar.Name = "monthCalendar"
        Me.txtFechaFin.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaFin.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaFin.Calendar.Size = New System.Drawing.Size(63, 174)
        Me.txtFechaFin.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFin.Calendar.TabIndex = 0
        Me.txtFechaFin.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaFin.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFin.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFin.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFin.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFin.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaFin.Calendar.NoneButton.Location = New System.Drawing.Point(-9, 0)
        Me.txtFechaFin.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaFin.Calendar.NoneButton.Text = "None"
        Me.txtFechaFin.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaFin.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFin.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFin.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFin.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFin.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaFin.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFin.Calendar.TodayButton.Size = New System.Drawing.Size(-9, 20)
        Me.txtFechaFin.Calendar.TodayButton.Text = "Today"
        Me.txtFechaFin.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaFin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFin.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaFin.Checked = False
        Me.txtFechaFin.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaFin.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFechaFin.DropDownImage = Nothing
        Me.txtFechaFin.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFin.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFin.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaFin.ForeColor = System.Drawing.Color.White
        Me.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFin.Location = New System.Drawing.Point(187, 64)
        Me.txtFechaFin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFin.MinValue = New Date(CType(0, Long))
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.ReadOnly = True
        Me.txtFechaFin.ShowCheckBox = False
        Me.txtFechaFin.ShowDropButton = False
        Me.txtFechaFin.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaFin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFin.TabIndex = 511
        Me.txtFechaFin.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.BackColor = System.Drawing.Color.OrangeRed
        Me.txtFechaInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaInicio.Calendar.AllowMultipleSelection = False
        Me.txtFechaInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaInicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.Name = "monthCalendar"
        Me.txtFechaInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaInicio.Calendar.Size = New System.Drawing.Size(64, 174)
        Me.txtFechaInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicio.Calendar.TabIndex = 0
        Me.txtFechaInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaInicio.Calendar.NoneButton.Location = New System.Drawing.Point(-8, 0)
        Me.txtFechaInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaInicio.Calendar.NoneButton.Text = "None"
        Me.txtFechaInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicio.Calendar.TodayButton.Size = New System.Drawing.Size(-8, 20)
        Me.txtFechaInicio.Calendar.TodayButton.Text = "Today"
        Me.txtFechaInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaInicio.Checked = False
        Me.txtFechaInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFechaInicio.DropDownImage = Nothing
        Me.txtFechaInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaInicio.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInicio.Location = New System.Drawing.Point(68, 64)
        Me.txtFechaInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.MinValue = New Date(CType(0, Long))
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.ReadOnly = True
        Me.txtFechaInicio.ShowCheckBox = False
        Me.txtFechaInicio.ShowDropButton = False
        Me.txtFechaInicio.Size = New System.Drawing.Size(68, 20)
        Me.txtFechaInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicio.TabIndex = 510
        Me.txtFechaInicio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(97, 32)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(275, 56)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(97, 32)
        Me.ButtonAdv2.TabIndex = 371
        Me.ButtonAdv2.Text = "     Generar"
        Me.ButtonAdv2.UseVisualStyle = True
        Me.ButtonAdv2.UseVisualStyleBackColor = False
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(97, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(833, 55)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(97, 32)
        Me.ButtonAdv1.TabIndex = 15
        Me.ButtonAdv1.Text = "Generar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        Me.ButtonAdv1.Visible = False
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.Controls.Add(Me.LblCabezera)
        Me.GradientPanel1.Location = New System.Drawing.Point(25, 12)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(922, 37)
        Me.GradientPanel1.TabIndex = 14
        '
        'LblCabezera
        '
        Me.LblCabezera.AutoSize = True
        Me.LblCabezera.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCabezera.ForeColor = System.Drawing.Color.Gray
        Me.LblCabezera.Location = New System.Drawing.Point(6, 3)
        Me.LblCabezera.Name = "LblCabezera"
        Me.LblCabezera.Size = New System.Drawing.Size(140, 17)
        Me.LblCabezera.TabIndex = 0
        Me.LblCabezera.Text = "CUENTAS POR Cobrar"
        '
        'LblTipoCuenta
        '
        Me.LblTipoCuenta.AutoSize = True
        Me.LblTipoCuenta.Location = New System.Drawing.Point(798, 73)
        Me.LblTipoCuenta.Name = "LblTipoCuenta"
        Me.LblTipoCuenta.Size = New System.Drawing.Size(19, 13)
        Me.LblTipoCuenta.TabIndex = 13
        Me.LblTipoCuenta.Text = "12"
        Me.LblTipoCuenta.Visible = False
        '
        'hhh
        '
        Me.hhh.AutoSize = True
        Me.hhh.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hhh.ForeColor = System.Drawing.Color.Gray
        Me.hhh.Location = New System.Drawing.Point(6, 3)
        Me.hhh.Name = "hhh"
        Me.hhh.Size = New System.Drawing.Size(361, 17)
        Me.hhh.TabIndex = 31
        Me.hhh.Text = "CUENTAS POR PAGAR COMERCIALES - RELACIONADAS 43"
        '
        'rptCuentaActivo
        '
        Me.rptCuentaActivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCuentaActivo.Location = New System.Drawing.Point(90, 124)
        Me.rptCuentaActivo.Name = "rptCuentaActivo"
        Me.rptCuentaActivo.Size = New System.Drawing.Size(794, 323)
        Me.rptCuentaActivo.TabIndex = 36
        '
        'frmEstadoCuentaActivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.SteelBlue
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(974, 447)
        Me.Controls.Add(Me.rptCuentaActivo)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.hhh)
        Me.Name = "frmEstadoCuentaActivo"
        Me.ShowIcon = False
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtFechaFin.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblTipoCuenta As System.Windows.Forms.Label
    Friend WithEvents hhh As System.Windows.Forms.Label
    Private WithEvents rptCuentaActivo As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents LblCabezera As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtFechaInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv

End Class
